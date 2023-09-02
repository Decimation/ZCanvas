global using TTask = ZCanvas.Lib.Todoist.Objects.Task;
using System.Text.Json;
using ZCanvas.Lib;
using ZCanvas.Lib.Todoist;
using Task = System.Threading.Tasks.Task;

namespace ZCanvas;

public static class Program
{
	public static async Task Main(string[] args)
	{
		var tok = Console.ReadLine();
		var t   = new TodoistClient(tok);
		var p   = await t.GetProjectsAsync();

		foreach (var project in p) {
			Console.WriteLine($"{project.Name} {project.Id} {project.ParentId}");
		}

		var tx = new TTask()
		{
			Content = "hello world",
			Labels =new List<string>() {"Assignment"},
			ProjectId = p.First(x=>x.Name=="Inbox").Id
		};

		Console.WriteLine(JsonSerializer.Serialize(tx, TodoistClient.JsonSerializerOptions));

		var tt = await t.CreateTaskAsync(tx);

		Console.WriteLine($"{tt}");

	}
}