using System.Text.Json.Serialization;
using SystemTextJsonCustomValueConverter.ValueConverters;

namespace SystemTextJsonCustomValueConverter.Models
{
    public class PositionPlayer
    {
        [JsonPropertyName("firstName")]
        public string Name { get; set; }
        
        [JsonPropertyName("primaryPosition")]
        [JsonConverter(typeof(PositionConverter))]
        public string Position { get; set; }
    }
}