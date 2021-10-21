using CostaSoftware.AspNetCoreDatabaseLocalizationDemo.Data;
using CostaSoftware.AspNetCoreDatabaseLocalizationDemo.Models;
using System.Linq;

namespace CostaSoftware.AspNetCoreDatabaseLocalizationDemo.Services
{
    public interface ILocalizationService
    {
        StringResource GetStringResource(string resourceName, int languageId);
    }

    public class LocalizationService : ILocalizationService
    {
        private readonly MyAppDbContext _context;

        public LocalizationService(MyAppDbContext context)
        {
            _context = context;
        }

        public StringResource GetStringResource(string resourceName, int languageId)
        {
            return _context.StringResources.FirstOrDefault(r => r.Name.ToLower() == resourceName.ToLower() && r.LanguageId == languageId);
        }
    }
}
