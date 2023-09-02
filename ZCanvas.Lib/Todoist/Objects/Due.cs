// Read S ZCanvas.Lib Due.cs
// 2023-09-01 @ 10:35 PM

#nullable disable
using System.Text.Json.Serialization;

namespace ZCanvas.Lib.Todoist.Objects;

public class Due
{
    [JsonPropertyName("date")]
    public string Date { get; set; }

    [JsonPropertyName("is_recurring")]
    public bool IsRecurring { get; set; }

    [JsonPropertyName("datetime")]
    public DateTime Datetime { get; set; }

    [JsonPropertyName("string")]
    public string String { get; set; }

    [JsonPropertyName("timezone")]
    public string Timezone { get; set; }
}