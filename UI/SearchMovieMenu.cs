using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReelRegistry.UI
{
    public class SearchMovieMenu
    {
        public static string SearchForMovieByGenre()
        {
            AnsiConsole.Clear();
            AnsiConsole.MarkupLine("[bold yellow]Search for a Movie by Genre[/]");

            var genre = new SelectionPrompt<string>().Title("Genre List");
            genre.AddChoice("Action");
            genre.AddChoice("Comedy");
            genre.AddChoice("Drama");
            genre.AddChoice("Horror");
            genre.AddChoice("Sci-Fi");

            var selectedGenre = AnsiConsole.Prompt(genre);
            
            return selectedGenre;
        }
    }
}
