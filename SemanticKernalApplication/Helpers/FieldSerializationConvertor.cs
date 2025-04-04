using System.Text.Json;
using System.Text.Json.Serialization;

namespace SemanticKernalApplication.WebAPI.Helpers
{
    public class EmptyStringConverter : JsonConverter<string>
    {
        public override bool HandleNull => true;

        public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return String.Empty;
            }
            if (reader.TokenType == JsonTokenType.Number)
            {
                var stringValue = reader.GetInt32();
                return stringValue.ToString();

            }
            else
            {
                return reader.GetString();
            }

        }

        public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options) =>
            writer.WriteStringValue(value ?? "");
    }
    public class DoubleToStringConverter : JsonConverter<double>
    {
        public override double Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return 0.00;
            }
            else if (reader.TryGetDouble(out var doubleValue))
            {
                return doubleValue;
            }
            else
                return 0.00;
        }

        public override void Write(Utf8JsonWriter writer, double value, JsonSerializerOptions options)
        {
            string formattedValue = value.ToString("0.00"); // Format to remove trailing .00
            writer.WriteStringValue(formattedValue);
        }
    }
    public class BooleanConverter : JsonConverter<bool>
    {
        public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {

            if (reader.TokenType == JsonTokenType.Null)
            {
                return false;
            }
            else
            {
                return reader.GetBoolean();
            }
        }

        public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
        {
            writer.WriteBooleanValue(value);
        }
    }
}
