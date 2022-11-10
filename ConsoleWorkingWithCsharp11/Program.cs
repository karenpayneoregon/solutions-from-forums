using ConsoleWorkingWithCsharp11.Classes;
using System.ComponentModel.DataAnnotations;

namespace ConsoleWorkingWithCsharp11;

internal partial class Program
{
    static async Task Main(string[] args)
    {
        await Task.Delay(0);
        //await GroupByEntityTypeSample.GroupBy_entity_type_SqlServer();

        GetSeason(11);
        ExitPrompt();
    }
}

