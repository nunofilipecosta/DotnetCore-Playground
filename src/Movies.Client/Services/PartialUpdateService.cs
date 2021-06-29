using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.JsonPatch;

using Newtonsoft.Json;

namespace Movies.Client.Services
{
    public class PartialUpdateService : IIntegrationService
    {
        private static HttpClient httpClient = new HttpClient();

        public PartialUpdateService()
        {
            httpClient.BaseAddress = new Uri("http://localhost:57863");
            httpClient.Timeout = new TimeSpan(0, 0, 30);
            httpClient.DefaultRequestHeaders.Clear();

        }


        public async Task Run()
        {
            await PatchResource();
            await PatchResourceShortcut();
        }


        public async Task PatchResource()
        {
            var patchDoc = new JsonPatchDocument<Models.MovieForUpdate>();
            patchDoc.Replace(m => m.Title, "Update title");
            patchDoc.Remove(m => m.Description);

            var serializeChangeSet = JsonConvert.SerializeObject(patchDoc);
            var request = new HttpRequestMessage(HttpMethod.Patch, "api/movies/5b1c2b4d-48c7-402a-80c3-cc796ad49c6b");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            request.Content = new StringContent(serializeChangeSet);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json-patch+json");

            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var updatedMovie = JsonConvert.DeserializeObject<Models.Movie>(content);
        }

        public async Task PatchResourceShortcut()
        {
            var patchDoc = new JsonPatchDocument<Models.MovieForUpdate>();
            patchDoc.Replace(m => m.Title, "Update title");
            patchDoc.Remove(m => m.Description);

            var response = await httpClient.PatchAsync("api/movies/5b1c2b4d-48c7-402a-80c3-cc796ad49c6b", new StringContent(JsonConvert.SerializeObject(patchDoc), Encoding.UTF8, "application/json-patch+json"));
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var updatedMovie = JsonConvert.DeserializeObject<Models.Movie>(content);

        }
    }
}
