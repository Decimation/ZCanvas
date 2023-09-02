// Read S ZCanvas.Lib Task.cs
// 2023-09-01 @ 10:36 PM

#nullable disable
using System.Text.Json.Serialization;

namespace ZCanvas.Lib.Todoist.Objects;

public class Task
{
    [JsonPropertyName("creator_id")]
    public long CreatorId { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("assignee_id")]
    public long AssigneeId { get; set; }

    [JsonPropertyName("assigner_id")]
    public long AssignerId { get; set; }

    [JsonPropertyName("comment_count")]
    public long CommentCount { get; set; }

    [JsonPropertyName("is_completed")]
    public bool IsCompleted { get; set; }

    [JsonPropertyName("content")]
    public string Content { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("due")]
    public Due Due { get; set; }

    [JsonPropertyName("duration")]
    public Duration Duration { get; set; }

    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("labels")]
    public List<string> Labels { get; set; }

    [JsonPropertyName("order")]
    public long Order { get; set; }

    [JsonPropertyName("priority")]
    public long Priority { get; set; }

    [JsonPropertyName("project_id")]
    public long? ProjectId { get; set; }

    [JsonPropertyName("section_id")]
    public long? SectionId { get; set; }

    [JsonPropertyName("parent_id")]
    public long? ParentId { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}