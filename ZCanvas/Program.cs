global using TTask = ZCanvas.Lib.Todoist.Objects.Task;
using System.Text.Json;
using System.Text.Json.Nodes;
using ZCanvas.Lib;
using ZCanvas.Lib.Canvas;
using ZCanvas.Lib.Todoist;
using Task = System.Threading.Tasks.Task;

namespace ZCanvas;

public static class Program
{
	public static async Task Main(string[] args)
	{
		var c  = new CanvasClient(Console.ReadLine());
		var cc = await c.GetCourses();
		foreach (var v in cc.AsArray()) {
			// Console.WriteLine($"{v}");

			Console.WriteLine($"{v["name"]} {v["id"]}");
			var a = await c.GetAssignments((v["id"].GetValue<int>()));

			foreach (var ass in a.AsArray()) {
				Console.WriteLine(ass);
			}
			Console.ReadKey();

		}
	}

	private static async Task Test1()
	{
		var tok      = Console.ReadLine();
		var client   = new TodoistClient(tok);
		var projects = await client.GetProjectsAsync();

		foreach (var project in projects) {
			Console.WriteLine($"{project.Name} {project.Id} {project.ParentId}");
		}

		var tx = new TTask()
		{
			Content   = "hello world",
			Labels    = new List<string>() { "Assignment" },
			ProjectId = projects.First(x => x.Name == "Inbox").Id
		};

		Console.WriteLine(JsonSerializer.Serialize(tx, TodoistClient.JsonSerializerOptions));

		var tt = await client.CreateTaskAsync(tx);

		Console.WriteLine($"{tt}");
	}
}