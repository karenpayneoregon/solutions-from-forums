using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace KP_ConsoleAppNet62.Classes;

public class Container
{
    [Key]
    public int Identifier { get; set; }

    public string Section { get; set; }

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

    // housed in RelatedList
    [JsonPropertyName("wuhcag_related")]
    public object[] CagRelated { get; set; }

    public List<Related> RelatedList { get; set; } = new();

    public override string ToString() => $"{Section,-10}{ConformanceLevel}";

}