using System.Security.Cryptography;
using System.Text.RegularExpressions;
using KP_ConsoleAppNet61.Classes;

namespace KP_ConsoleAppNet61;

internal partial class Program
{
    static void Main(string[] args)
    {
        /*
         * IMPORTANT: Change to a folder with many files with many files in sub-folders
         */
        var folder = @"c:\Users\****\Documents\Snagit";

        if (!Directory.Exists(folder))
        {
            AnsiConsole.MarkupLine($"[white on red]{folder} does not exists[/]");
            Console.ReadLine();
            return;
        }

        var directory = new DirectoryInfo(folder);
        Console.WriteLine($"File count {FileCount(directory)} in {folder}");
        var fileName = (directory.GetFiles().OrderByDescending(f => f.LastWriteTime)).First();
        Console.WriteLine($"File name {fileName}");

        Console.ReadLine();
    }
    public static int FileCount(DirectoryInfo directory) =>
        directory.EnumerateDirectories()
            .AsParallel()
            .SelectMany(di => di.EnumerateFiles("*.*", 
                SearchOption.AllDirectories))
            .Count();

    private static void RandomSample()
    {
        AnsiConsole.MarkupLine("[yellow]negative[/] and [cyan]positive[/]");
        AnsiConsole.MarkupLine("[white on blue]Generate Randoms![/]");

        var random = RandomNumberGenerator.Create();
        var bytes = new byte[sizeof(int)]; // 4 bytes
        random.GetNonZeroBytes(bytes);
        var result = BitConverter.ToInt32(bytes);
        AnsiConsole.MarkupLine(result < 0 ? $"[yellow]{result.Invert()}[/]" : $"[cyan]{result}[/]");
    }
}
