using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PatternsAndPractices.Adapter.ThirdPartyApi;

namespace PatternsAndPractices.Adapter
{
    public class ThirdPartyApiAdapter : PeopleDataAdapter
    {
        public const int MAX_RESULT_COUNT = 100;
        public override async Task<List<Person>> GetPeople()
        {
            var thirdPartyService = new ThirdPartyService();

            var result = await thirdPartyService.ListCharactersAsync(MAX_RESULT_COUNT).ConfigureAwait(false);

            return result.Select(dto => new Person { Name = dto.CharacterName, Gender = dto.Gender.ToString() }).ToList();
        }
    }
}
