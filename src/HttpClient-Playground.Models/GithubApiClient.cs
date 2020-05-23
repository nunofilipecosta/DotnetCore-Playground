using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HttpClient_Playground.Models
{
    public class GithubApiClient : ApiClient
    {
        public GithubApiClient() : base()
        {
            this.Client.BaseAddress = new Uri("https://api.github.com");
            this.Client.DefaultRequestHeaders.Add("User-Agent", "nunofilipecosta");
        }

        public async Task<IEnumerable<Repository>> GetRepositories()
        {
            var response = await this.SendAsync(HttpMethod.Get, "/repositories");
            var content = await response.Content.ReadAsStringAsync();

            var repositories = JsonConvert.DeserializeObject<IEnumerable<Repository>>(content);

            return repositories;
        }
    }
}
