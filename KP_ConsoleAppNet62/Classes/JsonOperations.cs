using System.Text.Json;

namespace KP_ConsoleAppNet62.Classes;
internal class JsonOperations
{
    private static string sourceFileName => "wcag.json";

    public static void Read()
    {
        var jsonString = File.ReadAllText(sourceFileName);
        List<Container> data = JsonSerializer.Deserialize<List<Container>>(jsonString);

        int primaryKey = 1;

        foreach (var container in data)
        {
            container.Identifier = primaryKey;
            primaryKey ++;

            Console.WriteLine(container.Id);
            var related = container.WuhcagRelated;
            if (related is not null)
            {
                string[] resultArray = Array.ConvertAll(related, x => x.ToString());
                foreach (var s in resultArray)
                {
                    var raw = s.Replace("{", "").Replace("}", "").RemoveWhitespace();
                    var item = raw.Split(',');


                    if (item.Length > 1)
                    {
                        Console.WriteLine($"\t{item[0].Substring(item[0].IndexOf(':') + 1)} {item[1].Substring(item[1].IndexOf(':') + 1)}");

                        container.RelatedList.Add(new Related()
                        {
                            Key = item[0].Substring(item[0].IndexOf(':') + 1),
                            ConformanceLevel = item[1].Substring(item[1].IndexOf(':') + 1)
                        });
                    }
                }
            }
        }

    }
}