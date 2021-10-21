using CostaSoftware.AspNetCoreDatabaseLocalizationDemo.Models;
using System.Collections.Generic;

namespace CostaSoftware.AspNetCoreDatabaseLocalizationDemo.Services
{
    public interface ILanguageService
    {
        IEnumerable<Language> GetLanguages();
        Language GetLanguageByCulture(string culture);
    }
}
