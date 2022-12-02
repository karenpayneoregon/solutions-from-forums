using GreetingsConsoleApp.Classes;
using Spectre.Console;

namespace GreetingsConsoleApp;

partial class Program
{
    public static void Main(string[] args)
    {
        string firstName = AnsiConsole.Prompt(
            new TextPrompt<string>("[cyan]First name[/]").PromptStyle("yellow")
            //.AllowEmpty()
        );

        if (!string.IsNullOrWhiteSpace(firstName))
        {
            AnsiConsole.MarkupLine($"[cyan]{Helpers.TimeOfDay()}[/] [yellow]{firstName}[/]");
            ExitPrompt();
        }
    }

}