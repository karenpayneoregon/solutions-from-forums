using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using NewtonsoftDateOnlyTimeOnlyApp.Classes;
using NewtonsoftDateOnlyTimeOnlyApp.Models;

namespace NewtonsoftDateOnlyTimeOnlyApp
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            AnsiConsole.MarkupLine("[white]Working with [/][cyan]DateOnly[/] [white]and[/] [cyan]TimeOnly[/] [white]using[/] [cyan]Newtonsoft.Json[/]");
            Console.WriteLine();

            var containers = Mocked.Container();
            string json = JsonConvert.SerializeObject(containers, Formatting.Indented);
            
            Console.WriteLine(json);

            Console.WriteLine();
            
            var readContainers = JsonConvert.DeserializeObject<List<Container>>(json);

            foreach (var container in readContainers)
            {
                Console.WriteLine($"{container.Id, -3}{container.FirstName, -10}{container.LastName, -15}{container.StartDate,-12} {container.StartTime}");
            }

            ExitPrompt();
        }
    }
}