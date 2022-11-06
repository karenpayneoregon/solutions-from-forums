using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace KP_ConsoleAppNet61;

internal partial class Program
{
    static void Main(string[] args)
    {
        var folder = @"c:\Users\paynek\Documents\Snagit";

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

public static class IntegerExtensions
{
    /// <summary>
    /// Flip negative to positive or positive to negative
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static int Invert(this int source) =>
        source * (-1);

    /// <summary>
    /// Flip negative to positive or positive to negative alternative via bitwise operation
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static int InvertBitwise(this int source) =>
        ~source + 1;
}