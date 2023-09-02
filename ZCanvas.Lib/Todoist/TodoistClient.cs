global using TTask = ZCanvas.Lib.Todoist.Objects.Task;
using System.Text.Json;
using Flurl.Http;
using System.Text.Json.Serialization;
using Flurl.Http.Configuration;
using JetBrains.Annotations;
using ZCanvas.Lib.Todoist.Objects;
using System.Text.Json.Serialization.Metadata;

#nullable disable
namespace ZCanvas.Lib.Todoist;

public class TodoistClient : IDisposable
{
	public static readonly JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions()
	{
		Converters =
		{
			new StringToIntConverter()
		},
		TypeInfoResolver = new DefaultJsonTypeInfoResolver()
		{
			Modifiers =
			{
				Modifiers.ExcludeEmptyStrings
			}
		}
	};

	public const string BASE_TODOIST_ENDPOINT = "https://api.todoist.com/rest/v2/";

	public FlurlClient Client { get; }

	public string Endpoint { get; } = BASE_TODOIST_ENDPOINT;

	public string Token { get; }

	public TodoistClient(string token)
	{
		Token = token;

		Client = new FlurlClient(Endpoint)
		{
			Headers =
			{
				{ "Authorization", $"Bearer {Token}" }
			},
			Settings =
			{
				Redirects =
				{
					Enabled                    = true,
					ForwardAuthorizationHeader = true,
					MaxAutoRedirects           = 20
				},
				JsonSerializer = new DefaultJsonSerializer(JsonSerializerOptions)
			},

		};
	}

	public async Task<Project[]> GetProjectsAsync()
	{
		var re = await Client.Request("projects").GetJsonAsync<Project[]>();

		return re;
	}

	public async Task<TTask> CreateTaskAsync(TTask t)
	{
		var req = Client.Request("tasks").PostJsonAsync(t);
		var re = await req;
		var o = await re.GetJsonAsync<TTask>();

		return o;
	}

	public void Dispose()
	{
		Client?.Dispose();
	}
}

public static class Modifiers
{
	public static void ExcludeEmptyStrings(JsonTypeInfo jsonTypeInfo)
	{
		if (jsonTypeInfo.Kind != JsonTypeInfoKind.Object)
			return;

		foreach (JsonPropertyInfo jsonPropertyInfo in jsonTypeInfo.Properties) {
			if (jsonPropertyInfo.PropertyType == typeof(string)) {
				jsonPropertyInfo.ShouldSerialize = static (obj, value) =>
				{
					return !string.IsNullOrEmpty((string) value);
				};
			}

			else if (jsonPropertyInfo.PropertyType == typeof(long)) {
				jsonPropertyInfo.ShouldSerialize = static (obj, value) =>
				{
					return ((long) value) != 0;
				};
			}

			else if (jsonPropertyInfo.PropertyType == typeof(long?)) {
				jsonPropertyInfo.ShouldSerialize = static (obj, value) =>
				{
					return ((long?) value).HasValue;
				};
			}
			else if (jsonPropertyInfo.PropertyType == typeof(DateTime))
			{
				jsonPropertyInfo.ShouldSerialize = static (obj, value) =>
				{
					return ((DateTime)value) != default;
				};
			}
			else {
				jsonPropertyInfo.ShouldSerialize = static (obj, value) =>
				{
					return value != null;
				};
			}
		}
	}
}

public class StringToIntConverter : JsonConverter<long>
{
	public override long Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		if (reader.TokenType == JsonTokenType.String) {
			if (long.TryParse(reader.GetString(), out long intValue)) {
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