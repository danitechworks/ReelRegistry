using ReelRegistry.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReelRegistry.Services
{
    public class AppService
    {

        public static void RunApp()
        {
            while (true)
            {
                var choice = UI.MainMenu.DisplayMainMenu();
                switch (choice)
                {
                    case "View all movies":
                        var movieRepository = new Repositories.MovieRepository();
                        var movies = movieRepository.GetAllMovies();
                        DisplayMovieMenu.DisplayMovies(movies);
                        break;
                    case "Search for a movie":                       
                        

                        break;
                    case "Add a new movie":
                        // Implement add functionality
                        break;
                    case "Remove a movie":
                        // Implement remove functionality
                        break;
                    case "Exit":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
