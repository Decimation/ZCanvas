// Read S ZCanvas.Lib Project.cs
// 2023-09-01 @ 10:36 PM

#nullable disable
using System.Text.Json.Serialization;

namespace ZCanvas.Lib.Todoist.Objects;

//[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]

public class Project
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("comment_count")]
    public long CommentCount { get; set; }

    [JsonPropertyName("color")]
    public string Color { get; set; }

    [JsonPropertyName("is_shared")]
    public bool IsShared { get; set; }

    [JsonPropertyName("order")]
    public long Order { get; set; }

    [JsonPropertyName("is_favorite")]
    public bool IsFavorite { get; set; }

    [JsonPropertyName("is_inbox_project")]
    public bool IsInboxProject { get; set; }

    [JsonPropertyName("is_team_inbox")]
    public bool IsTeamInbox { get; set; }

    [JsonPropertyName("view_style")]
    public string ViewStyle { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("parent_id")]
    public long? ParentId { get; set; }
}