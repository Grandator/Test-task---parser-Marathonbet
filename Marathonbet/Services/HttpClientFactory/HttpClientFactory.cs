using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Marathonbet.Services.HttpClientFactory
{
    public class HttpClientFactory : IHttpClientFactory
    {
        static string baseAddress = "https://mobile.marathonbet.com";

        public HttpClient CreateClient()
        {
            ServicePointManager.DefaultConnectionLimit = int.MaxValue; // fix 503 error ?
            var client = new HttpClient();
            SetupClientDefaults(client);
            return client;
        }

        protected virtual void SetupClientDefaults(HttpClient client)
        {
            client.Timeout = TimeSpan.FromSeconds(30); //set your own timeout.
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Linux; Android 6.0; Nexus 5 Build/MRA58N) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/76.0.3809.100 Mobile Safari/537.36");
        }
    }
}
