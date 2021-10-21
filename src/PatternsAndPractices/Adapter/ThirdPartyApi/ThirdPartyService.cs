using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace PatternsAndPractices.Adapter.ThirdPartyApi
{
    public static class ThirdPartyService
    {
        public static async System.Threading.Tasks.Task<List<PersonDTO>> ListCharactersAsync(int count)
        {
            var people = new List<PersonDTO>();

            using (var client = new HttpClient())
            {
                Uri url = new Uri("https://swapi.co/api/people");
                string result = await client.GetStringAsync(url).ConfigureAwait(true);
                people = JsonConvert.DeserializeObject<PersonDTOApiResult>(result).Results;
            }

            return people.Take(count).ToList();
        }
    }

}
