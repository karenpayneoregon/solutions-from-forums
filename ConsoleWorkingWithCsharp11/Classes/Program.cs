using ConsoleWorkingWithCsharp11.Classes;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using static ConsoleWorkingWithCsharp11.Classes.Helpers;

// ReSharper disable once CheckNamespace
namespace ConsoleWorkingWithCsharp11;

internal partial class Program
{
    private static void NewLineInterpolations()
    {
        Helpers.PrintSampleName();
        Console.WriteLine($"Greeting is {
            Greeting
                .For
                .TimeOfDay()}");
    }

    private static void GenericMath()
    {
        Helpers.PrintSampleName();

        var integers = new[] { 1, 2, 3, 4, 5 };
        var doubles = new[] { 0.1, 0.7, 1.1, 8.3 };

        AnsiConsole.MarkupLine($"Add two int with Helpers.Add [white on blue]{Add(1, 2)}[/]");
        AnsiConsole.MarkupLine($"Add two double with Helpers.Add [yellow on blue]{Add(1.5m, 2.45m)}[/]");

        AnsiConsole.MarkupLine($"Helpers.Sum(integers) [white on blue]{Sum(integers)}[/]");
        AnsiConsole.MarkupLine($"Helpers.Sum(doubles) [white on blue]{Sum(doubles):F}[/]");

        Console.WriteLine();

        var integerResult = Helpers.AddAll1(integers);
        var doubleResult = Helpers.AddAll1(doubles);

        AnsiConsole.MarkupLine($"[yellow]integerResult[/] {integerResult}");
        AnsiConsole.MarkupLine($" [yellow]doubleResult[/] {doubleResult}");

    }
    private static void RequiredModifier()
    {
        Helpers.PrintSampleName();

        /*
         * uses required modifier
         * to enforce constructors and callers to initialize those values
         */
        Person person = new() { FirstName = "", LastName = "", Email = ""};
    }

    /// <summary>
    /// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/patterns#list-patterns
    /// </summary>
    private static void ListAndSlicePattern()
    {
        Helpers.PrintSampleName();

        int[] list1 = { 1, 2, 3, 4, 5 };

        if (list1 is [1, 2, 3, 4, 5] && list1 is [ _ , _ , _ , _ ,  5 ])
        {
            AnsiConsole.MarkupLine("[white on blue]List Pattern Matched[/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[white on red]No match[/]");
        }

        Console.WriteLine();

        var list2 = new[] { 1, 2, 3, 4, 5, 6 };

        if (list2 is [1, 2, .. var values, 6])
        {
            AnsiConsole.MarkupLine($"[white on gray]{string.Join(",", values)}[/]");
        }

        Console.WriteLine();

        int[] numbers = { 24, 320, 32, 700 };

        string arrayDesc = numbers switch
        {
            [24, 320, 32, 700] => "[yellow]It's the array we expected![/]",
            _ => "[yellow on red]no match[/]"
        };

        AnsiConsole.MarkupLine(arrayDesc);

    }

    /// <summary>
    /// Nothing special other than the connection string using Encrypt=False
    /// </summary>
    private static async Task EntityFrameworkGetCustomers()
    {
        Helpers.PrintSampleName();

        var customers = await DataOperations.ReadCustomersAsync();
        var table = CreateTableEntityFramework();

        foreach (var customer in customers)
        {
            table.AddRow(
                customer.Identifier.ToString(),
                customer.CompanyName,
                customer.ContactFirstName,
                customer.ContactLastName,
                customer.GenderNavigation.GenderType,
                customer.ContactTypeNavigation.ContactType);
        }

        AnsiConsole.Write(table);
    }

    private static void RawStringLiterals()
    {
        Helpers.PrintSampleName();

        string text = "[red]I've been injected[/] ";
        string longMessage = $$"""
            This is a long message.
            It has several lines.
                Some are indented
                        more than others. {{text}}
            Some should start at the first column.
            Some have "quoted text" in them.
            """;

        AnsiConsole.MarkupLine("[white on blue]Raw string literals[/]");
        Console.WriteLine();
        AnsiConsole.MarkupLine(longMessage);

    }

    private string FullName([Required] Person person) 
        => $"{person.FirstName} {person.LastName}";

    public static void GetSeason(int month)
    {
        string season = "The season is " + $"{month switch
        {
            1 or 2 or 12 => "Winter",
            > 2 and < 6 => "Spring",
            > 5 and < 9 => "Summer",
            > 8 and < 12 => "Autumn",
            _ => "unknown. Wrong month number",
        }}.";

        AnsiConsole.MarkupLine($"Season for [cyan]{CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month)}[/] is [cyan]{season}[/]");
    }

    #region Screen helpers
    public static Table CreateTableEntityFramework() => new Table()
        .RoundedBorder()
        .AddColumn("[cyan]Id[/]")
        .AddColumn("[cyan]Company[/]")
        .AddColumn("[cyan]First[/]")
        .AddColumn("[cyan]Last[/]")
        .AddColumn("[cyan]Gender[/]")
        .AddColumn("[cyan]Contact type[/]")
        .Alignment(Justify.Center)
        .BorderColor(Color.LightSlateGrey)
        .Title("[LightGreen]Customers[/]");

    private static void Render(Rule rule)
    {
        AnsiConsole.Write(rule);
        AnsiConsole.WriteLine();
    }

    private static void ExitPrompt()
    {
        Console.WriteLine();
        Render(new Rule($"[yellow]Press a key to exit the demo[/]")
            .RuleStyle(Style.Parse("silver"))
            .Centered());
        Console.ReadLine();
    } 
    #endregion
}