
namespace KP_ConsoleAppNet62.Classes;

public class Related
{
    public string Section { get; set; }
    public string ConformanceLevel { get; set; }
    public override string ToString() => $"{Section, -10}{ConformanceLevel}";

}
