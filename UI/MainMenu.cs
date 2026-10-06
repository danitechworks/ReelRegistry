using System;
using System.Collections.Generic;
using System.Text;
using Spectre.Console;

namespace ReelRegistry.UI
{
    public class MainMenu
    {

        public static string DisplayMainMenu()
        {
            AnsiConsole.Clear();
            AnsiConsole.Markup("Welcome to ReelRegistry!\n");

            var menu = new SelectionPrompt<string>().Title("Registry Menu");
            menu.AddChoice("View all movies");
            menu.AddChoice("Search for a movie");
            menu.AddChoice("Add a new movie");
            menu.AddChoice("Remove a movie");
            menu.AddChoice("Exit");

            var choice = AnsiConsole.Prompt(menu);
            return choice;
        }

        
    }
}
