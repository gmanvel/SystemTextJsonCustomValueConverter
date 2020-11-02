using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SystemTextJsonCustomValueConverter.ValueConverters
{
    public class BatSideConverter: JsonConverter<string>
    {
        public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
                throw new JsonException();

            var currentDepth = reader.CurrentDepth;

            reader.Read();

            while (reader.TokenType != JsonTokenType.PropertyName
                   ||
                   !reader.GetString().Equals("batSide", StringComparison.OrdinalIgnoreCase))
                reader.Read();

            var batSide = JsonSerializer.Deserialize<BatSide>(ref reader);
            
            while (reader.TokenType != JsonTokenType.EndObject || reader.CurrentDepth != currentDepth)
                reader.Read();

            return batSide.Description;
        }

        private class BatSide
        {
            [JsonPropertyName("code")]
            public string Code { get; set; }

            [JsonPropertyName("description")]
            public string Description { get; set; }
        }

        public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}