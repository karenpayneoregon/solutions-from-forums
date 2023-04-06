using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace KP_ConsoleAppNet62;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        AnsiConsole.MarkupLine("");
        Console.Title = "Code sample";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
}

public interface ISystemClock
{
    DateTime Now { get; }
}
public class FixedDateClock : ISystemClock
{
    private readonly DateTime _when;

    public FixedDateClock(DateTime when)
    {
        _when = when;
    }

    public DateTime Now => _when;
}