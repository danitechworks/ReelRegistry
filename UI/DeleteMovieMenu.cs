using ReelRegistry.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReelRegistry.UI
{
    public class DeleteMovieMenu
    {
        public static Movie DisplayRemoveMovieMenu(List<Movie> movies)
        {
            AnsiConsole.Clear();
            AnsiConsole.MarkupLine("[bold yellow]Remove a Movie[/]");

            var movie = AnsiConsole.Prompt(
            new SelectionPrompt<Movie>()
                .Title("Select a movie to remove:")
                .UseConverter(m => $"{m.Title} ({m.Year})")
                .AddChoices(movies));

            return movie;

        }
    }
}
