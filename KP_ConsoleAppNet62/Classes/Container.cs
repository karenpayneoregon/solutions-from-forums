using System.Text.Json.Serialization;

namespace KP_ConsoleAppNet62.Classes;

public class Container
{
    [JsonPropertyName("key")]
    public string Key { get; set; }
    [JsonPropertyName("id")]
    public string Id { get; set; }
    [JsonPropertyName("title")]
    public string Title { get; set; }
    [JsonPropertyName("description")]
    public string Description { get; set; }
    [JsonPropertyName("uri")]
    public string Uri { get; set; }
    [JsonPropertyName("conformance_level")]
    public string ConformanceLevel { get; set; }
    [JsonPropertyName("wuhcag_summary")]
    public string Summary { get; set; }
    [JsonPropertyName("wuhcag_detail")]
    public string Detail { get; set; }
    [JsonPropertyName("wuhcag_tips")]
    public string Tips { get; set; }
    [JsonPropertyName("wuhcag_what_to_do")]
    public string Remedy { get; set; }
    [JsonPropertyName("wuhcag_exceptions")]
    public string Exceptions { get; set; }
    [JsonPropertyName("wuhcag_related")]
    public object[] WuhcagRelated { get; set; }
    public List<Related> RelatedList { get; set; } = new();
    public string wuchcag_exceptions { get; set; }

    public override string ToString() => $"{Key,-10}{ConformanceLevel}";

}