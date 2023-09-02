// Read S ZCanvas.Lib StringToLongConverter.cs
// 2023-09-01 @ 11:02 PM

#nullable disable
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZCanvas.Lib.Utilities;

public class StringToLongConverter : JsonConverter<long>
{
    //todo

    public override long Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            if (long.TryParse(reader.GetString(), out long intValue))
            {
                return intValue;
            }
        }

        // You can handle the conversion error here, e.g., throw an exception or return a default value
        return 0; // Default value in case of conversion failure
    }

    public override void Write(Utf8JsonWriter writer, long value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value);
    }
}