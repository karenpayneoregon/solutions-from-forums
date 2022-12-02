using System.Runtime.CompilerServices;
using ConsoleHelperLibrary.Classes;
using Spectre.Console;

// ReSharper disable once CheckNamespace
namespace GreetingsConsoleApp;

internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Code sample: Simple";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
        AnsiConsole.MarkupLine("[cyan]Starter targeting .NET Core 6 and .NET Core 7[/]");
        Console.WriteLine();
    }
    private static void Render(Rule rule)
    {
        AnsiConsole.Write(rule);
        AnsiConsole.WriteLine();
    }

    private static void ExitPrompt()
    {
        Console.WriteLine();
        Render(new Rule($"[white on blue]Press a key to exit[/]").RuleStyle(Style.Parse("cyan")).Centered());
        Console.ReadLine();
    }
}