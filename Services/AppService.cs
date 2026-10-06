using ReelRegistry.Repositories;
using ReelRegistry.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReelRegistry.Services
{
    public class AppService
    {

        public static async Task RunAppAsync()
        {
            bool running = true;

            while (running)
            {    
                var choice = MainMenu.DisplayMainMenu();
                var movieRepository = new MovieRepository();
                var genreRepository = new GenreRepository();            

                switch (choice)
                {
                    case "View all movies":
                        {
                            var movieList = movieRepository.GetAllMoviesAsync().Result;
                            DisplayMovieMenu.DisplayMovies(movieList);
                            break;
                        }

                    case "Search for a movie by genre":
                        {
                            var genre = SearchMovieMenu.SearchForMovieByGenre();
                            var movieList = movieRepository.GetMoviesByGenre(genre);
                            DisplayMovieMenu.DisplayMovies(movieList);
                            break;
                        }

                    case "Add a new movie":
                        {
                            var genres = genreRepository.GetAllGenres();
                            var movie = AddMovieMenu.DisplayAddMovieMenu(genres);

                            movieRepository.AddMovie(movie);
                            break;
                        }
                    case "Remove a movie":
                        {
                            var movieList = movieRepository.GetAllMoviesAsync().Result;
                            var movie = DeleteMovieMenu.DisplayRemoveMovieMenu(movieList);
                            movieRepository.RemoveMovie(movie);
                            break;
                        }
                        
                    case "Exit":
                        {
                            running = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                        }
                        
                }
            }
        }
    }
}
