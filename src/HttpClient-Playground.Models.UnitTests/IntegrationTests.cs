using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Xunit;


namespace HttpClient_Playground.Models.UnitTests
{
    public class IntegrationTests
    {
        // 2.x
        [Fact]
        public async Task ShouldReturnHelloWorld_Legacy()
        {
            // Build your "app"
            var webHostBuilder = new WebHostBuilder()
                .Configure(app => app.Run(async ctx =>
                        await ctx.Response.WriteAsync("Hello World!")
                ));

            // Configure the in-memory test server, and create an HttpClient for interacting with it
            var server = new TestServer(webHostBuilder);
            HttpClient client = server.CreateClient();

            // Send requests just as if you were going over the network
            var response = await client.GetAsync("/");

            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Equal("Hello World!", responseString);
        }


        [Fact]
        public async Task ShouldReturnHelloWorld()
        {
            var hostBuilder = new HostBuilder()
                .ConfigureWebHost(webHostBuilder =>
                {
                    webHostBuilder.UseTestServer();
                    webHostBuilder.Configure(app => app.Run(async ctx => await ctx.Response.WriteAsync("Hello World!!!")));
                 });

            var host = await hostBuilder.StartAsync();

            HttpClient client = host.GetTestClient();

            var response = await client.GetAsync("/");

            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Equal("Hello World!!!", responseString);
        }
    }
}
