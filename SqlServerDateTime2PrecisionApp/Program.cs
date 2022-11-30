using SqlServerDateTime2PrecisionApp.Classes;

namespace SqlServerDateTime2PrecisionApp
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Parse("2022-11-01T00:00:00"));
            DateTime2Operations.GetCreatedColumnDateTime();
            Console.ReadLine();
        }
    }
}