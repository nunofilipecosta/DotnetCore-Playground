using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PatternsAndPractices.Adapter
{
    public class StarWarsApiPeopleAdapter : PeopleDataAdapter
    {
        public override async Task<List<Person>> GetPeople()
        {
            var people = new List<Person>();

            using (var client = new HttpClient())
            {
                Uri url = new Uri("https://swapi.co/api/people", UriKind.Absolute);
                string result = await client.GetStringAsync(url).ConfigureAwait(false);
                people = JsonConvert.DeserializeObject<ApiResult<Person>>(result).Results;
            }

            return people;
        }
    }
}
