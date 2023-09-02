// Read S ZCanvas.Lib JsonModifiers.cs
// 2023-09-01 @ 11:02 PM

#nullable disable
using System.Text.Json.Serialization.Metadata;

namespace ZCanvas.Lib.Utilities;

public static class JsonModifiers
{
    public static void ExcludeNullOrDefault(JsonTypeInfo jsonTypeInfo)
    {
        //todo

        if (jsonTypeInfo.Kind != JsonTypeInfoKind.Object)
            return;

        foreach (JsonPropertyInfo jsonPropertyInfo in jsonTypeInfo.Properties)
        {
            if (jsonPropertyInfo.PropertyType == typeof(string))
            {
                jsonPropertyInfo.ShouldSerialize = static (obj, value) =>
                {
                    return !string.IsNullOrEmpty((string)value);
                };
            }

            else if (jsonPropertyInfo.PropertyType == typeof(long))
            {
                jsonPropertyInfo.ShouldSerialize = static (obj, value) =>
                {
                    return (long)value != 0;
                };
            }

            else if (jsonPropertyInfo.PropertyType == typeof(long?))
            {
                jsonPropertyInfo.ShouldSerialize = static (obj, value) =>
                {
                    return ((long?)value).HasValue;
                };
            }
            else if (jsonPropertyInfo.PropertyType == typeof(DateTime))
            {
                jsonPropertyInfo.ShouldSerialize = static (obj, value) =>
                {
                    return (DateTime)value != default;
                };
            }
            else
            {
                jsonPropertyInfo.ShouldSerialize = static (obj, value) =>
                {
                    return value != null;
                };
            }
        }
    }
}