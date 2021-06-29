using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Marvin.StreamExtensions;
using Movies.Client.Models;

namespace Movies.Client.Services
{
    public class CancellationService : IIntegrationService
    {
        private static readonly HttpClient httpClient = new(new HttpClientHandler { AutomaticDecompression = System.Net.DecompressionMethods.GZip });

        private readonly CancellationTokenSource cancellationTokenSource = new();


        public CancellationService()
        {
            httpClient.BaseAddress = new Uri("http://localhost:57863");
            httpClient.Timeout = new TimeSpan(0, 0, 2);
            httpClient.DefaultRequestHeaders.Clear();
        }

        public async Task Run()
        {
            cancellationTokenSource.CancelAfter(1000);
            //await GetTrailerAndCancel(cancellationTokenSource.Token);
            await GetTrailerAndHandleTimeout();
        }

        private async Task GetTrailerAndCancel(CancellationToken cancellationToken)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"api/movies/d8663e5e-7494-4f81-8739-6e0de1bea7ee/trailers/{Guid.NewGuid()}");

            request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.AcceptEncoding.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue("gzip"));

            try
            {
                using (var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationTokenSource.Token))
                {
                    var stream = await response.Content.ReadAsStreamAsync();

                    response.EnsureSuccessStatusCode();
                    var trailer = stream.ReadAndDeserializeFromJson<Trailer>();
                }
            }
            catch (OperationCanceledException operationCanceledException)
            {
                Console.WriteLine($"An operation was cancelled with message {operationCanceledException.Message}");
            }
        }

        private async Task GetTrailerAndHandleTimeout()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"api/movies/d8663e5e-7494-4f81-8739-6e0de1bea7ee/trailers/{Guid.NewGuid()}");

            request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.AcceptEncoding.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue("gzip"));

            try
            {
                using (var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
                {
                    var stream = await response.Content.ReadAsStreamAsync();

                    response.EnsureSuccessStatusCode();
                    var trailer = stream.ReadAndDeserializeFromJson<Trailer>();
                }
            }
            catch (OperationCanceledException operationCanceledException)
            {
                Console.WriteLine($"An operation was cancelled with message {operationCanceledException.Message}");
            }
        }
    }
}
