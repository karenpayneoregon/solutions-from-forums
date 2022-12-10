using SLD = SqlServerLibrary.DataHelpers;

namespace MSBuildUsingExampleApp
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SLD.ExpressDatabaseExists("NorthWind2022") ? "Exists" : "Not found");
            Console.ReadLine();
        }
    }
}