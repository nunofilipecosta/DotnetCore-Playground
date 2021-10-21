using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PatternsAndPractices.Adapter.ThirdPartyApi;

namespace PatternsAndPractices.Adapter
{
    public class ThirdPartyApiAdapter : PeopleDataAdapter
    {
        public const int MAXRESULTCOUNT = 100;
        public override async Task<List<Person>> GetPeople()
        {
            var result = await ThirdPartyService.ListCharactersAsync(MAXRESULTCOUNT).ConfigureAwait(false);

            return result.Select(dto => new Person { Name = dto.CharacterName, Gender = dto.Gender.ToString() }).ToList();
        }
    }
}
