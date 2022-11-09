using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ConsoleWorkingWithCsharp11.Models;

public static class NameOfScope
{
    [Display(Name = nameof(favoritePerson))]
    public static void Hello(string favoritePerson)
    {
        AnsiConsole.MarkupLine($"[cyan]Hello,[/] [mediumspringgreen]{favoritePerson}[/]");
    }

    public static void Execute()
    {
        var method = typeof(NameOfScope).GetMethod(nameof(Hello), BindingFlags.Static | BindingFlags.Public);
        var attribute = method!.GetCustomAttribute<DisplayAttribute>();

        AnsiConsole.MarkupLine($"[cyan]The attribute name is[/] [yellow]\"{attribute!.Name}[/]\"");
    }
}