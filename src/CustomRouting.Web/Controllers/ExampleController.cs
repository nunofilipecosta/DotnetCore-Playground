using System.Text;
using System.Threading.Tasks;

namespace CustomRouting.Web.Controllers
{
    public class ExampleController
    {
        public async Task<string> Marco()
        {
            return await Task.FromResult("Polo").ConfigureAwait(false);
        }

        public async Task<string> Echo(EchoRequest echoRequest)
        {
            var echoBuilder = new StringBuilder();

            for (int i = 0; i < echoRequest.EchoCount; i++)
            {
                echoBuilder.Append($" {echoRequest.Content}...");
            }

            return await Task.FromResult(echoBuilder.ToString()).ConfigureAwait(false);
        }
    }
}
