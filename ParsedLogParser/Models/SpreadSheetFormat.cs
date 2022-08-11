using System.Text.Json.Serialization;

namespace ParsedLogParser.Models
{
    public class SpreadSheetFormat
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("damageDone")]
        public int DamageDone { get; set; }
    }
}