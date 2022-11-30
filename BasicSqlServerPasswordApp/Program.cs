using BasicSqlServerPasswordApp.Classes;

namespace BasicSqlServerPasswordApp;

internal partial class Program
{
    static void Main(string[] args)
    {

        var (success, id) = DataOperations.ValidateUser3("payneoregn", "!FirstOnMonday".ToSecureString());
        SpectreOperations.DrawHeader();
        
        var name = SpectreOperations.AskLoginName();
        var password = SpectreOperations.AskPassword();
        
        Console.Clear();

        if (Sample3(name,password))
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

    // old, may not be supported in newer versions of SQL-Server
    private static bool Sample1(string userName, string password) => DataOperations.ValidateUser(userName, password!.ToSecureString()!);
    // does separate checks for name and password
    private static bool Sample2(string userName, string password) => DataOperations.ValidateUser1(userName, password!.ToSecureString()!);
    // does combined name and password in one statement
    private static bool Sample3(string userName, string password) => DataOperations.ValidateUser2(userName, password!.ToSecureString()!);

}