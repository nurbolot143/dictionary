using System.Net.Http.Headers;
using System.Text;

namespace Infrastructure.EndpointClients;

public sealed class EndpointClientFactory
{
    private readonly IHttpClientFactory _httpClientFactory;

    public EndpointClientFactory(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public HttpClient CreateHttpClient(EndpointClientConfiguration configuration)
    {
        var httpClient = _httpClientFactory.CreateClient();

        var baseUri = configuration.BaseUri;
        if (!baseUri.EndsWith("/"))
            baseUri += "/";

        httpClient.BaseAddress = new Uri(baseUri);

        var authToken = Encoding.ASCII.GetBytes($"{configuration.UserName}:{configuration.Password}");
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authToken));

        return httpClient;
    }
}