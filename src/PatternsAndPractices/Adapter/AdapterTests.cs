using System;
using System.Text;
using System.Threading.Tasks;
using Xunit;
namespace PatternsAndPractices.Adapter
{
    public class AdapterTests
    {
        [Fact]
        public async Task ListCharactersGivenStarWarsApiAdapterShouldReturnSomething()
        {
            var swAdapter = new StarWarsApiPeopleAdapter();
            var service = new StarWarsCharacterDisplayService(swAdapter);

            await CallListCharactersAndAssertContainsExpectedCharacters(service).ConfigureAwait(false);
        }

        [Fact]
        public async Task ListCharactersGivenLocalFileAdapterShouldReturnSomething()
        {
            var localAdapter = new LocalFilePeopleAdapter();
            var service = new StarWarsCharacterDisplayService(localAdapter);

            await CallListCharactersAndAssertContainsExpectedCharacters(service).ConfigureAwait(false);
        }

        [Fact]
        public async Task ListCharactersGivenThirdPartyApiAdapterShouldReturnSomething()
        {
            var adapter = new ThirdPartyApiAdapter();
            var service = new StarWarsCharacterDisplayService(adapter);

            await CallListCharactersAndAssertContainsExpectedCharacters(service).ConfigureAwait(false);
        }



        private static async Task CallListCharactersAndAssertContainsExpectedCharacters(StarWarsCharacterDisplayService service)
        {
            var result = await service.ListCharacters().ConfigureAwait(false);

            Assert.Contains("Luke Skywalker", result, StringComparison.OrdinalIgnoreCase);
            Assert.Contains("Darth Vader", result, StringComparison.OrdinalIgnoreCase);
        }
    }
}
