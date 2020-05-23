using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HttpClient_Playground.Models
{
    public abstract class ApiClient
    {
        protected HttpClient Client { get; }

        public ApiClient()
        {
            this.Client = HttpClientFactory.Create();
        }

        public ApiClient(HttpClient httpClient)
        {
            this.Client = httpClient;
        }

        public async Task<HttpResponseMessage> SendAsync(HttpMethod httpMethod, string uri, object content = null)
        {
            var requestMessage = new HttpRequestMessage(httpMethod, new Uri(this.Client.BaseAddress, new Uri(uri, UriKind.Relative)));

            if (content != null)
            {
                // Use the data as request content, if it's not an http content it will be sent as a json payload
                requestMessage.Content = content as HttpContent ?? new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
            }

            return await this.Client.SendAsync(requestMessage);
        }
    }
}