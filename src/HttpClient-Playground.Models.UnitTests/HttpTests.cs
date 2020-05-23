using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace HttpClient_Playground.Models.UnitTests
{
    public class HttpTests : IClassFixture<CustomWebApplicationFactory>
    {
        readonly CustomWebApplicationFactory _factory;
        readonly HttpClient _client;

        public HttpTests(CustomWebApplicationFactory factory, ITestOutputHelper output)
        {
            _factory = factory;
            _factory.Output = output;
            _client = factory.CreateClient(new Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactoryClientOptions { AllowAutoRedirect = true, BaseAddress = new Uri("http://localhost:41267/") });
        }

        [Fact]
        public async Task CanCallApi()
        {
            var result = await _client.GetAsync("/values");

            result.EnsureSuccessStatusCode();

            var content = await result.Content.ReadAsStringAsync();
            Assert.Contains("Welcome", content);
        }
    }
}
