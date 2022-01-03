using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CostaSoftware.Logging.Web.Pages
{
    public class PrivacyModel : PageModel
    {
        [BindProperty]
        public string Name { get; set; } = "";

        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await Task.CompletedTask;

            return RedirectToPage("./Index");
        }
    }
}