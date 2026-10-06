using System;
using System.Collections.Generic;
using System.Text;
using Spectre.Console;
using ReelRegistry.Models;

namespace ReelRegistry.UI
{
    public class AddMovieMenu
    {
        public static Movie DisplayAddMovieMenu(List<Genre> genres)
        {
            AnsiConsole.Clear();
            AnsiConsole.MarkupLine("Add a New Movie");

            var title = AnsiConsole.Ask<string>("Enter the [green]title[/]:");
            var year = AnsiConsole.Ask<int>("Enter the [green]year[/]:");

            var genre = AnsiConsole.Prompt(
                new SelectionPrompt<Genre>()
                    .Title("Select a [green]genre[/]:")
                    .UseConverter(g => g.Name)
                    .AddChoices(genres));

            return new Movie
            {
                Title = title,
                Year = year,
                GenreId = genre.Id
            };
        }
    }
}
