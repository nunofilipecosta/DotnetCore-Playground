using System;
using System.Linq;
using Xunit;

namespace HttpClient_Playground.Models.UnitTests
{
    public class GithubClientTests
    {
        [Fact]
        public async void GetRepositories()
        {
            var apiClient = new GithubApiClient();
            var repositories = await apiClient.GetRepositories();

            Assert.NotNull(repositories);
            Assert.True(repositories.ToList().Count > 0);
        }
    }
}
