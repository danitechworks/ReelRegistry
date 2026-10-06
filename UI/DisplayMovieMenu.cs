using ReelRegistry.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReelRegistry.UI
{
    public class DisplayMovieMenu
    {
        public static void DisplayMovies(List<Movie> movies)
        {
            AnsiConsole.Clear();
            AnsiConsole.MarkupLine("[bold yellow]Movie List[/]");

            var table = new Table();
            table.Border = TableBorder.Rounded;
            table.AddColumn("Title");
            table.AddColumn("Year");
            table.AddColumn("Genre");

            foreach (var movie in movies)
            {
                table.AddRow(movie.Title, movie.Year.ToString(), movie.GenreName);
            }
            AnsiConsole.Write(table);

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }
    }
}
