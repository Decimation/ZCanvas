// Read S ZCanvas.Lib Duration.cs
// 2023-09-01 @ 10:35 PM

#nullable disable
using System.Text.Json.Serialization;

namespace ZCanvas.Lib.Todoist.Objects;

public class Duration
{
    [JsonPropertyName("amount")]
    public long Amount { get; set; }

    [JsonPropertyName("unit")]
    public string Unit { get; set; }
}