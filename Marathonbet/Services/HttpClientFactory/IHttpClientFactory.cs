using System.Net.Http;

namespace Marathonbet.Services.HttpClientFactory
{
    public interface IHttpClientFactory
    {
        HttpClient CreateClient();
    }
}
