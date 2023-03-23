namespace KP_ConsoleAppNet62.Classes;

public static class LocalExtensions
{
    public static string RemoveWhitespace(this string input) =>
        new(input.ToCharArray()
            .Where(c => !char.IsWhiteSpace(c))
            .ToArray());
}