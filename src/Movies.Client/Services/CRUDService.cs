using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Movies.Client.Services
{
    public class CRUDService : IIntegrationService
    {
        private static HttpClient httpClient = new HttpClient();

        public CRUDService()
        {
            httpClient.BaseAddress = new Uri("http://localhost:57863");
            httpClient.Timeout = new TimeSpan(0, 0, 30);
            httpClient.DefaultRequestHeaders.Clear();

            // set on the HttpRequestMessage or use the shortcuts
            //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml", 0.9));
        }

        public async Task Run()
        {
            //await GetResource();
            await GetResourceThroughHttpRequestMessage();
            await CreateResource();
            await UpdateResource();
            await DeleteResource();
        }

        public async Task GetResource()
        {
            var response = await httpClient.GetAsync("api/movies");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var movies = new List<Models.Movie>();
            if (response.Content.Headers.ContentType.MediaType == "application/json")
            {
                movies = JsonSerializer.Deserialize<List<Models.Movie>>(content, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }
            else if (response.Content.Headers.ContentType.MediaType == "application/xml")
            {
                var serializer = new XmlSerializer(typeof(List<Models.Movie>));
                movies = (List<Models.Movie>)serializer.Deserialize(new StringReader(content));
            }
        }

        public async Task GetResourceThroughHttpRequestMessage()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "api/movies");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            var movies = JsonSerializer.Deserialize<List<Models.Movie>>(content, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
        }

        public async Task CreateResource()
        {
            var movieToCreate = new Models.MovieForCreation()
            {
                Title = "Resevoir Dogs",
                Description = "After a simple jewelry heist goes terribly wrong, the surviving criminals begin to suspect that one of them is a police informant.",
                DirectorId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                ReleaseDate = new DateTime(1992, 9, 2),
                Genre = "Crime, Drama"

            };

            var serializedMovieToCreate = JsonSerializer.Serialize(movieToCreate);

            var request = new HttpRequestMessage(HttpMethod.Post, "api/movies");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            request.Content = new StringContent(serializedMovieToCreate);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var createdMovie = JsonSerializer.Deserialize<Models.Movie>(content, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
        }

        public async Task CreateResourceShortcut()
        {
            var movieToCreate = new Models.MovieForCreation()
            {
                Title = "Resevoir Dogs",
                Description = "After a simple jewelry heist goes terribly wrong, the surviving criminals begin to suspect that one of them is a police informant.",
                DirectorId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                ReleaseDate = new DateTime(1992, 9, 2),
                Genre = "Crime, Drama"

            };

            var response = await httpClient.PostAsync("api/movie", new StringContent(JsonSerializer.Serialize(movieToCreate), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateResource()
        {
            var movieToUpdate = new Models.MovieForUpdate()
            {
                Title = "pulp Fiction",
                Description = "The movie with Zed.",
                DirectorId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                ReleaseDate = new DateTime(1992, 9, 2),
                Genre = "Crime, Drama"
            };

            var serializedMovieToUpdate = JsonSerializer.Serialize(movieToUpdate);

            var request = new HttpRequestMessage(HttpMethod.Put, "api/movies/5b1c2b4d-48c7-402a-80c3-cc796ad49c6b");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            request.Content = new StringContent(serializedMovieToUpdate);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var updatedMovie = JsonSerializer.Deserialize<Models.Movie>(content, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
        }

        public async Task UpdateResourceShortcut()
        {
            var movieToUpdate = new Models.MovieForUpdate()
            {
                Title = "pulp Fiction",
                Description = "The movie with Zed.",
                DirectorId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                ReleaseDate = new DateTime(1992, 9, 2),
                Genre = "Crime, Drama"
            };

            var response = await httpClient.PutAsync("api/movies/5b1c2b4d-48c7-402a-80c3-cc796ad49c6b", new StringContent(JsonSerializer.Serialize(movieToUpdate), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteResource()
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, "api/movies/5b1c2b4d-48c7-402a-80c3-cc796ad49c6b");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

        }

        public async Task DeleteResourceShortcut()
        {
            var response = await httpClient.DeleteAsync("api/movies/5b1c2b4d-48c7-402a-80c3-cc796ad49c6b");
        }

    }
}