using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CostaSoftware.Logging.Web.Pages
{
    public class AboutModel : PageModel
    {
        private readonly ILogger _logger;
        public AboutModel(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("CustomLogger");
        }

        public void OnGet()
        {
            _logger.LogTrace("Trace message");
            _logger.LogDebug("Debug message");
            _logger.LogInformation("Information message");
            _logger.LogWarning("Warning message");
            _logger.LogError("Error message");
            _logger.LogCritical("Critical message");
        }
    }
}
