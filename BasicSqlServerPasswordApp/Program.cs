using BasicSqlServerPasswordApp.Classes;

namespace BasicSqlServerPasswordApp;

internal partial class Program
{
    static void Main(string[] args)
    {

        SpectreOperations.DrawHeader();
        
        var name = SpectreOperations.AskLoginName();
        var password = SpectreOperations.AskPassword();
        
        Console.Clear();

        if (Sample1(name,password))
        {
            SpectreOperations.DrawWelcomeHeader();
        }
        else
        {
            SpectreOperations.DrawGoAwayHeader();
        }

        AnsiConsole.MarkupLine("[white on blue]Exit[/]");
        Console.ReadLine();

    }

    private static bool Sample1(string userName, string password) => DataOperations.ValidateUser(userName, password!.ToSecureString()!);
    private static bool Sample2(string userName, string password) => DataOperations.ValidateUser1(userName, password!.ToSecureString()!);

}