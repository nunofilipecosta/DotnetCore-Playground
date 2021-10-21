using CostaSoftware.AspNetCoreDatabaseLocalizationDemo.Data;
using CostaSoftware.AspNetCoreDatabaseLocalizationDemo.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace CostaSoftware.AspNetCoreDatabaseLocalizationDemo.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly MyAppDbContext _context;

        public LanguageService(MyAppDbContext context) => _context = context;

        public Language GetLanguageByCulture(string culture) => _context.Languages.FirstOrDefault(l => l.Culture.ToLower() == culture.ToLower());

        public IEnumerable<Language> GetLanguages() => _context.Languages.ToList();
    }

    public class LanguageServiceWrapper
    {
        private readonly IServiceScopeFactory serviceScopeFactory;

        public LanguageServiceWrapper(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }

        public IEnumerable<Language> GetLanguages()
        {
            using var scope = this.serviceScopeFactory.CreateScope();
            var languageService = scope.ServiceProvider.GetRequiredService<ILanguageService>();


            return languageService.GetLanguages();
        }
    }
}
