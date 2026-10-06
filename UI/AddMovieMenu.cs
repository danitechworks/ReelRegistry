using System;
using System.Collections.Generic;
using System.Text;
using Spectre.Console;
using ReelRegistry.Models;

namespace ReelRegistry.UI
{
    public class AddMovieMenu
    {
        public static Movie DisplayAddMovieMenu()
        {
            AnsiConsole.Clear();
            AnsiConsole.Markup("Add a New Movie\n");

            var title = AnsiConsole.Ask<string>("Enter the [green]title[/]:");
            var year = AnsiConsole.Ask<int>("Enter the [green]year[/]:");  
            
            var genre = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select a [green]genre[/]:")
                    .AddChoices(new[] { "Action", "Comedy", "Drama", "Horror", "Sci-Fi", "Romance" }));

            return new Movie
            {
                Title = title,
                Year = year,
                //GenreId = GenreController.GetGenreId(genre)
            };
        }
    }
}
