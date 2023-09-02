// Read S ZCanvas.Lib BaseClient.cs
// 2023-09-01 @ 11:10 PM

#nullable disable
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using Flurl.Http;
using Flurl.Http.Configuration;
using ZCanvas.Lib.Utilities;

namespace ZCanvas.Lib;

public abstract class BaseClient : IDisposable
{
    public static readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
        Converters =
        {
            new StringToLongConverter()
        },
        TypeInfoResolver = new DefaultJsonTypeInfoResolver()
        {
            Modifiers =
            {
                JsonModifiers.ExcludeNullOrDefault
            }
        }
    };

    public FlurlClient Client { get; }

    public string Endpoint { get; }

    public string Token { get; }

    protected BaseClient(string endpoint, string token)
    {
        Endpoint = endpoint;
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

    public virtual void Dispose()
    {
        Client.Dispose();
    }
}