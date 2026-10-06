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
                            var movieList = await movieRepository.GetAllMoviesAsync();
                            DisplayMovieMenu.DisplayMovies(movieList);
                            break;
                        }

                    case "Search for a movie by genre":
                        {
                            var genre = SearchMovieMenu.SearchForMovieByGenre();
                            var movieList = await movieRepository.GetMoviesByGenreAsync(genre);
                            DisplayMovieMenu.DisplayMovies(movieList);
                            break;
                        }

                    case "Add a new movie":
                        {
                            var genres = await genreRepository.GetAllGenresAsync();
                            var movie = AddMovieMenu.DisplayAddMovieMenu(genres);

                            await movieRepository.AddMovieAsync(movie);
                            break;
                        }
                    case "Remove a movie":
                        {
                            var movieList = await movieRepository.GetAllMoviesAsync();
                            var movie = DeleteMovieMenu.DisplayRemoveMovieMenu(movieList);
                            await movieRepository.RemoveMovieAsync(movie);
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
