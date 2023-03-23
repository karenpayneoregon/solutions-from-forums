using System.Text.Json;
using KP_ConsoleAppNet62.Classes;
using KP_ConsoleAppNet62.Data;
using KP_ConsoleAppNet62.Models;
using Container = KP_ConsoleAppNet62.Models.Container;

namespace KP_ConsoleAppNet62;

internal partial class Program
{
    private static int _counter = 1;

    static void Main(string[] args)
    {

        JsonOperations.Read();
        Console.ReadLine();
        return;

        // table seeded with three duplicate records out of 100
        using var context = new Context();

        var list = context.Person.ToList();
        Console.WriteLine($"Total records (has duplicates) {list.Count}");

        list = list.DistinctBy(p => new { p.FirstName, p.LastName }).ToList();

        Console.WriteLine($"DistinctBy {list.Count}");

        List<Person> distinctList = context.Person.ToList()
            .GroupBy(p => new { p.FirstName, p.LastName })
            .Select(group => group.First())
            .ToList();

        Console.WriteLine($"GroupBy {list.Count}");
        Console.WriteLine();

        Console.ReadLine();
    }

    private static void RawStringLiteralSimple()
    {
        var input = """
        {
            "@context": "https ://www.w3.org/ns/activitystreams", 
            "type": "Object",
            "id": "http://www.test.example/object/l",
            "name": "A Simple, non-specific object"
        }
        """;

        Console.WriteLine(input);
        var json = JsonSerializer.Deserialize<Container>(input);
    }
}

