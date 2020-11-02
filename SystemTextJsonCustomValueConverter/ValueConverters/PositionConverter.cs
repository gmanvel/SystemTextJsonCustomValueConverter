using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SystemTextJsonCustomValueConverter.ValueConverters
{
    public class PositionConverter : JsonConverter<string>
    {
        public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            while (reader.TokenType != JsonTokenType.PropertyName || reader.GetString() != "abbreviation")
                reader.Read();

            // read to move to a value
            reader.Read();

            var position = reader.GetString();

            while (reader.TokenType != JsonTokenType.EndObject)
                reader.Read();

            return position;
        }

        public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options) =>
            writer.WriteStringValue(value);
    }
}