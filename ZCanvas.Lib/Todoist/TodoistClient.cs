global using TTask = ZCanvas.Lib.Todoist.Objects.Task;
using Flurl.Http;
using JetBrains.Annotations;
using ZCanvas.Lib.Todoist.Objects;

#nullable disable
namespace ZCanvas.Lib.Todoist;

public class TodoistClient : BaseClient
{
	public const string BASE_TODOIST_ENDPOINT = "https://api.todoist.com/rest/v2/";

	public TodoistClient(string token) : base(BASE_TODOIST_ENDPOINT, token)
	{
	}

	public async Task<Project[]> GetProjectsAsync()
	{
		var re = await Client.Request("projects").GetJsonAsync<Project[]>();

		return re;
	}

	public async Task<TTask> CreateTaskAsync(TTask t)
	{
		var req = Client.Request("tasks").PostJsonAsync(t);
		var re  = await req;
		var o   = await re.GetJsonAsync<TTask>();

		return o;
	}
}