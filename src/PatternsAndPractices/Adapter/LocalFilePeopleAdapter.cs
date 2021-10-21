using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PatternsAndPractices.Adapter
{
    public class LocalFilePeopleAdapter : PeopleDataAdapter
    {
        public override async Task<List<Person>> GetPeople()
        {
            string filePath = @"Adapter/People.json";
            return JsonConvert.DeserializeObject<List<Person>>(await File.ReadAllTextAsync(filePath).ConfigureAwait(false));
        }
    }
}
