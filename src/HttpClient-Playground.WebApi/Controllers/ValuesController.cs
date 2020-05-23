using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HttpClient_Playground.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private static HttpClient httpClient = new HttpClient();
        public ValuesController()
        {
            httpClient.BaseAddress = new Uri("https://api.github.com");
            httpClient.Timeout = new TimeSpan(0, 0, 30);
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "nunofilipecosta");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
        }


        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<dynamic>> Get()
        {
            var response = await httpClient.GetAsync("/repositories");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var repositories = JsonConvert.DeserializeObject<IEnumerable<dynamic>>(content);

            var request2 = new HttpRequestMessage(HttpMethod.Get, "repositories");
            request2.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            request2.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response2 = await httpClient.SendAsync(request2);
            response.EnsureSuccessStatusCode();
            var content2 = await response.Content.ReadAsStringAsync();
            var repositories2 = JsonConvert.DeserializeObject<IEnumerable<dynamic>>(content);


            

            return repositories;
        }
    }
}
