using System.Text.Json;
using KP_ConsoleAppNet62.Data;
using KP_ConsoleAppNet62.Models;

namespace KP_ConsoleAppNet62;

internal partial class Program
{
    private static int _counter = 1;

    static void Main(string[] args)
    {


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

        var input = """
        {
            "@context": "https ://www.w3.org/ns/activitystreams", 
            "type": "Object",
            "id": "http://www.test.example/object/l",
            "name": "A Simple, non-specific object"
        }
        """;

        Console.WriteLine(input);
        var json = JsonSerializer.Deserialize<Rootobject>(input);
        Console.ReadLine();
    }

    private static void RandomExample()
    {
        Helper.Initialize(20);
        for (int index = 0; index < 25; index++)
        {
            var (success, value) = Helper.TryGet();
            if (success)
            {
                Console.WriteLine($"{value} {_counter}");
                _counter++;
            }
            else
            {
                Console.WriteLine("HashSet is empty");
                break;
            }
        }
    }
}

public class Helper
{
    private static HashSet<string> HashSet;

    public static void Initialize(int capacity)
    {
        HashSet = new HashSet<string>();
        for (int index = 0; index < capacity; index++)
        {
            HashSet.Add(GenerateRandomString());
        }
    }

    public static (bool success, string value) TryGet()
    {
        if (HashSet.Count > 0)
        {
            var value = HashSet.FirstOrDefault();
            HashSet.Remove(HashSet.FirstOrDefault()!);
            return (true, value)!;
        }
        else
        {
            return (false, null)!;
        }
    }
    public static string GenerateRandomString(int length = 5)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        var random = new Random();
        return new string(Enumerable.Repeat(chars, length)
            .Select(item => item[random.Next(item.Length)]).ToArray());
    }

}


public class Rootobject
{
    public string context { get; set; }
    public string type { get; set; }
    public string id { get; set; }
    public string name { get; set; }
}
