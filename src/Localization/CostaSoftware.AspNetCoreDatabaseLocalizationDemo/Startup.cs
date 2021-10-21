using CostaSoftware.AspNetCoreDatabaseLocalizationDemo.Data;
using CostaSoftware.AspNetCoreDatabaseLocalizationDemo.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CostaSoftware.AspNetCoreDatabaseLocalizationDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLocalization();
            services.AddControllersWithViews().AddViewLocalization();
            services.AddDbContext<MyAppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<ILocalizationService, LocalizationService>();


            //var serviceProvider = services.BuildServiceProvider();
            //var languageService = serviceProvider.GetRequiredService<ILanguageService>();
            //var languages = languageService.GetLanguages();
            //var cultures = languages.Select(x => new CultureInfo(x.Culture)).ToArray();

            //services.Configure<RequestLocalizationOptions>(options =>
            //{
            //    var englishCulture = cultures.FirstOrDefault(x => x.Name == "en-US");

            //    options.DefaultRequestCulture = new RequestCulture(englishCulture?.Name ?? "en-US");
            //    options.SupportedCultures = cultures;
            //    options.SupportedUICultures = cultures;
            //});


            services.AddSingleton<LanguageServiceWrapper>();
            services.AddOptions<RequestLocalizationOptions>().Configure<LanguageServiceWrapper>((options, languageService) =>
            {
                var languages = languageService.GetLanguages();
                var cultures2 = languages.Select(x => new CultureInfo(x.Culture)).ToArray();

                var englishCulture = cultures2.FirstOrDefault(x => x.Name == "en-US");
                options.DefaultRequestCulture = new RequestCulture(englishCulture?.Name ?? "en-US");
                options.SupportedCultures = cultures2;
                options.SupportedUICultures = cultures2;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseRequestLocalization();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
