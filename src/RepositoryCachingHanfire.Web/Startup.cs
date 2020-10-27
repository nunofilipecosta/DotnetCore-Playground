using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RepositoryCachingHanfire.Core.Configurations;
using RepositoryCachingHanfire.Core.Enums;
using RepositoryCachingHanfire.Core.Interfaces;
using RepositoryCachingHanfire.Infrastructure;
using RepositoryCachingHanfire.Infrastructure.Repositories;
using RepositoryCachingHanfire.Infrastructure.Services;
using System;

namespace RepositoryCachingHanfire.Web
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RepositoryCachingHanfire.Web", Version = "v1" });
            });

            services.AddDbContext<ApplicationDbContext>(optionsBuilder =>
            optionsBuilder.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection"),
                optionsBuilder =>
                    optionsBuilder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.Configure<CacheConfiguration>(Configuration.GetSection("CacheConfiguration"));

            services.AddMemoryCache();
            services.AddTransient<MemoryCacheService>();
            services.AddTransient<RedisCacheService>();
            services.AddTransient<Func<CacheTech, ICacheService>>(serviceProvider => key =>
            {
                switch (key)
                {
                    case CacheTech.Redis:
                        return serviceProvider.GetService<RedisCacheService>();
                    case CacheTech.Memory:
                        return serviceProvider.GetService<MemoryCacheService>();
                    default:
                        return serviceProvider.GetService<MemoryCacheService>();
                }
            });

            services.AddHangfire(configuration => configuration.UseSqlServerStorage(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<ICustomerRepository, CustomerRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RepositoryCachingHanfire.Web v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseHangfireDashboard("/jobs");
        }
    }
}
