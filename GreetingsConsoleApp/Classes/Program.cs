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

    /// <summary>
    /// This is to demo R# ability to convert the string to a raw string literal
    /// </summary>
    public static void Demo()
    {
        var json = @"[
  {
    ""Name"": ""Product 1"",
    ""ExpiryDate"": ""2000-12-29T00:00:00Z"",
    ""Price"": 99.95,
    ""Sizes"": null
  },
  {
    ""Name"": ""Product 2"",
    ""ExpiryDate"": ""2009-07-31T00:00:00Z"",
    ""Price"": 12.50,
    ""Sizes"": null
  }
]";
        Console.WriteLine(json);
    }
}