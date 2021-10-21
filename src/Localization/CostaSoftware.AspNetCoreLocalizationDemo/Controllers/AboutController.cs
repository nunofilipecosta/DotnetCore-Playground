using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace CostaSoftware.AspNetCoreLocalizationDemo.Controllers
{
    public class AboutController : Controller
    {
        private readonly IStringLocalizer<AboutController> _stringLocalizer;

        public AboutController(IStringLocalizer<AboutController> stringLocalizer)
        {
            this._stringLocalizer = stringLocalizer;
        }

        public IActionResult Index()
        {
            ViewData["PageTitle"] = _stringLocalizer["page.title"].Value;

            return View();
        }
    }
}
