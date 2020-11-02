using System.Text.Json.Serialization;
using SystemTextJsonCustomValueConverter.ValueConverters;

namespace SystemTextJsonCustomValueConverter.Models
{
    public class DexterityPlayer
    {
        [JsonPropertyName("firstName")]
        public string Name { get; set; }

        [JsonPropertyName("dexterity")]
        [JsonConverter(typeof(BatSideConverter))]
        public string BatSide { get; set; }
    }
}