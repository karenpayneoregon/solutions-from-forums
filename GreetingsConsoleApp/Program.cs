using GreetingsConsoleApp.Classes;

namespace GreetingsConsoleApp;

partial class Program
{
    public static void Main(string[] args)
    {
        // mocked data
        var values = Enumerable.Range(1, 100).Select(Convert.ToDouble);
        // mix up values
        var mixedUp = values.Shuffle().ToList();
        // get lowest 10
        var result = mixedUp.OrderBy(x => x).Take(10).ToList();

        Console.WriteLine(string.Join(",", result));
        Console.ReadLine();
    }

}

public static class EnumerableExtensions
{
    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        => source.Shuffle(new Random());

    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random random)
        => source.Iterator(random);

    private static IEnumerable<T> Iterator<T>(this IEnumerable<T> source, Random random)
    {
        List<T> buffer = source.ToList();

        for (int index = 0; index < buffer.Count; index++)
        {
            int next = random.Next(index, buffer.Count);
            yield return buffer[next];

            buffer[next] = buffer[index];
        }
    }
}