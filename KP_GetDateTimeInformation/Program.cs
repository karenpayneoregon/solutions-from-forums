using KP_GetDateTimeInformation.Classes;
using SqlServerLibrary;

namespace KP_GetDateTimeInformation;

internal partial class Program
{
    static async Task Main(string[] args)
    {
        await Setup();

        var cs = DataConnections.Instance.MainConnection;

        var tableNames = DataHelpers.GetTableNames(cs);
        foreach (var tableName in tableNames)
        {
            var (list, hasColumns) = DataHelpers.GetDateTimeInformation1(cs, tableName);
            if (!hasColumns) continue;
            AnsiConsole.MarkupLine($"[cyan]Table:[/] [yellow]{tableName}[/]");
            foreach (var item in list)
            {
                Console.WriteLine($"\tColumn: {item.ColumnName} ");
            }
        }

        var populated = DataHelpers.TablesArePopulated(cs);
        AnsiConsole.MarkupLine(populated ? 
            "[green]Tables are populated[/]" : 
            "[red]Tables are not populated[/]");

        ExitPrompt();
    }
}