using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Flurl.Http;

namespace ZCanvas.Lib.Canvas;

public class CanvasClient : BaseClient
{
	public const string BASE_CANVAS_ENDPOINT = "http://canvas.umn.edu/api/v1/";

	public CanvasClient(string token, string endpoint = BASE_CANVAS_ENDPOINT) : base(endpoint, token) { }

	public async Task<JsonNode> GetCourses()
	{
		var req = await Client.Request("courses").GetAsync();

		var b = JsonValue.Parse(await req.GetStreamAsync());

		return b;
	}

	public async Task<JsonNode> GetAssignments(int id)
	{
		var req = await Client.Request("courses",id,"assignments").GetAsync();

		var b = JsonValue.Parse(await req.GetStreamAsync());

		return b;
	}
}
// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
public class IntegrationData
{
	[JsonPropertyName("5678")]
	public string _5678 { get; set; }
}

public class NeedsGradingCountBySection
{
	[JsonPropertyName("section_id")]
	public string SectionId { get; set; }

	[JsonPropertyName("needs_grading_count")]
	public int NeedsGradingCount { get; set; }
}

public class Root
{
	[JsonPropertyName("id")]
	public int Id { get; set; }

	[JsonPropertyName("name")]
	public string Name { get; set; }

	[JsonPropertyName("description")]
	public string Description { get; set; }

	[JsonPropertyName("created_at")]
	public DateTime CreatedAt { get; set; }

	[JsonPropertyName("updated_at")]
	public DateTime UpdatedAt { get; set; }

	[JsonPropertyName("due_at")]
	public DateTime DueAt { get; set; }

	[JsonPropertyName("lock_at")]
	public DateTime LockAt { get; set; }

	[JsonPropertyName("unlock_at")]
	public DateTime UnlockAt { get; set; }

	[JsonPropertyName("has_overrides")]
	public bool HasOverrides { get; set; }

	[JsonPropertyName("all_dates")]
	public object AllDates { get; set; }

	[JsonPropertyName("course_id")]
	public int CourseId { get; set; }

	[JsonPropertyName("html_url")]
	public string HtmlUrl { get; set; }

	[JsonPropertyName("submissions_download_url")]
	public string SubmissionsDownloadUrl { get; set; }

	[JsonPropertyName("assignment_group_id")]
	public int AssignmentGroupId { get; set; }

	[JsonPropertyName("due_date_required")]
	public bool DueDateRequired { get; set; }

	[JsonPropertyName("allowed_extensions")]
	public List<string> AllowedExtensions { get; set; }

	[JsonPropertyName("max_name_length")]
	public int MaxNameLength { get; set; }

	[JsonPropertyName("turnitin_enabled")]
	public bool TurnitinEnabled { get; set; }

	[JsonPropertyName("vericite_enabled")]
	public bool VericiteEnabled { get; set; }

	[JsonPropertyName("turnitin_settings")]
	public object TurnitinSettings { get; set; }

	[JsonPropertyName("grade_group_students_individually")]
	public bool GradeGroupStudentsIndividually { get; set; }

	[JsonPropertyName("external_tool_tag_attributes")]
	public object ExternalToolTagAttributes { get; set; }

	[JsonPropertyName("peer_reviews")]
	public bool PeerReviews { get; set; }

	[JsonPropertyName("automatic_peer_reviews")]
	public bool AutomaticPeerReviews { get; set; }

	[JsonPropertyName("peer_review_count")]
	public int PeerReviewCount { get; set; }

	[JsonPropertyName("peer_reviews_assign_at")]
	public DateTime PeerReviewsAssignAt { get; set; }

	[JsonPropertyName("intra_group_peer_reviews")]
	public bool IntraGroupPeerReviews { get; set; }

	[JsonPropertyName("group_category_id")]
	public int GroupCategoryId { get; set; }

	[JsonPropertyName("needs_grading_count")]
	public int NeedsGradingCount { get; set; }

	[JsonPropertyName("needs_grading_count_by_section")]
	public List<NeedsGradingCountBySection> NeedsGradingCountBySection { get; set; }

	[JsonPropertyName("position")]
	public int Position { get; set; }

	[JsonPropertyName("post_to_sis")]
	public bool PostToSis { get; set; }

	[JsonPropertyName("integration_id")]
	public string IntegrationId { get; set; }

	[JsonPropertyName("integration_data")]
	public string IntegrationData { get; set; }

	[JsonPropertyName("points_possible")]
	public double PointsPossible { get; set; }

	[JsonPropertyName("submission_types")]
	public List<string> SubmissionTypes { get; set; }

	[JsonPropertyName("has_submitted_submissions")]
	public bool HasSubmittedSubmissions { get; set; }

	[JsonPropertyName("grading_type")]
	public string GradingType { get; set; }

	[JsonPropertyName("grading_standard_id")]
	public object GradingStandardId { get; set; }

	[JsonPropertyName("published")]
	public bool Published { get; set; }

	[JsonPropertyName("unpublishable")]
	public bool Unpublishable { get; set; }

	[JsonPropertyName("only_visible_to_overrides")]
	public bool OnlyVisibleToOverrides { get; set; }

	[JsonPropertyName("locked_for_user")]
	public bool LockedForUser { get; set; }

	[JsonPropertyName("lock_info")]
	public object LockInfo { get; set; }

	[JsonPropertyName("lock_explanation")]
	public string LockExplanation { get; set; }

	[JsonPropertyName("quiz_id")]
	public int QuizId { get; set; }

	[JsonPropertyName("anonymous_submissions")]
	public bool AnonymousSubmissions { get; set; }

	[JsonPropertyName("discussion_topic")]
	public object DiscussionTopic { get; set; }

	[JsonPropertyName("freeze_on_copy")]
	public bool FreezeOnCopy { get; set; }

	[JsonPropertyName("frozen")]
	public bool Frozen { get; set; }

	[JsonPropertyName("frozen_attributes")]
	public List<string> FrozenAttributes { get; set; }

	[JsonPropertyName("submission")]
	public object Submission { get; set; }

	[JsonPropertyName("use_rubric_for_grading")]
	public bool UseRubricForGrading { get; set; }

	[JsonPropertyName("rubric_settings")]
	public RubricSettings RubricSettings { get; set; }

	[JsonPropertyName("rubric")]
	public object Rubric { get; set; }

	[JsonPropertyName("assignment_visibility")]
	public List<int> AssignmentVisibility { get; set; }

	[JsonPropertyName("overrides")]
	public object Overrides { get; set; }

	[JsonPropertyName("omit_from_final_grade")]
	public bool OmitFromFinalGrade { get; set; }

	[JsonPropertyName("hide_in_gradebook")]
	public bool HideInGradebook { get; set; }

	[JsonPropertyName("moderated_grading")]
	public bool ModeratedGrading { get; set; }

	[JsonPropertyName("grader_count")]
	public int GraderCount { get; set; }

	[JsonPropertyName("final_grader_id")]
	public int FinalGraderId { get; set; }

	[JsonPropertyName("grader_comments_visible_to_graders")]
	public bool GraderCommentsVisibleToGraders { get; set; }

	[JsonPropertyName("graders_anonymous_to_graders")]
	public bool GradersAnonymousToGraders { get; set; }

	[JsonPropertyName("grader_names_visible_to_final_grader")]
	public bool GraderNamesVisibleToFinalGrader { get; set; }

	[JsonPropertyName("anonymous_grading")]
	public bool AnonymousGrading { get; set; }

	[JsonPropertyName("allowed_attempts")]
	public int AllowedAttempts { get; set; }

	[JsonPropertyName("post_manually")]
	public bool PostManually { get; set; }

	[JsonPropertyName("score_statistics")]
	public object ScoreStatistics { get; set; }

	[JsonPropertyName("can_submit")]
	public bool CanSubmit { get; set; }

	[JsonPropertyName("annotatable_attachment_id")]
	public object AnnotatableAttachmentId { get; set; }

	[JsonPropertyName("anonymize_students")]
	public bool AnonymizeStudents { get; set; }

	[JsonPropertyName("require_lockdown_browser")]
	public bool RequireLockdownBrowser { get; set; }

	[JsonPropertyName("important_dates")]
	public bool ImportantDates { get; set; }

	[JsonPropertyName("muted")]
	public bool Muted { get; set; }

	[JsonPropertyName("anonymous_peer_reviews")]
	public bool AnonymousPeerReviews { get; set; }

	[JsonPropertyName("anonymous_instructor_annotations")]
	public bool AnonymousInstructorAnnotations { get; set; }

	[JsonPropertyName("graded_submissions_exist")]
	public bool GradedSubmissionsExist { get; set; }

	[JsonPropertyName("is_quiz_assignment")]
	public bool IsQuizAssignment { get; set; }

	[JsonPropertyName("in_closed_grading_period")]
	public bool InClosedGradingPeriod { get; set; }

	[JsonPropertyName("can_duplicate")]
	public bool CanDuplicate { get; set; }

	[JsonPropertyName("original_course_id")]
	public int OriginalCourseId { get; set; }

	[JsonPropertyName("original_assignment_id")]
	public int OriginalAssignmentId { get; set; }

	[JsonPropertyName("original_lti_resource_link_id")]
	public int OriginalLtiResourceLinkId { get; set; }

	[JsonPropertyName("original_assignment_name")]
	public string OriginalAssignmentName { get; set; }

	[JsonPropertyName("original_quiz_id")]
	public int OriginalQuizId { get; set; }

	[JsonPropertyName("workflow_state")]
	public string WorkflowState { get; set; }
}

public class RubricSettings
{
	[JsonPropertyName("points_possible")]
	public string PointsPossible { get; set; }
}

