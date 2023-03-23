
namespace KP_ConsoleAppNet62.Classes;

public class Related
{
    public string Key { get; set; }
    public string ConformanceLevel { get; set; }
    public override string ToString() => $"{Key, -10}{ConformanceLevel}";

}
