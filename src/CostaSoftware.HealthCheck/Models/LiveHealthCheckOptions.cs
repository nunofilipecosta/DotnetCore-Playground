using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Net.Mime;

namespace CostaSoftware.HealthCheck.Models
{
    public class LiveHealthCheckOptions : HealthCheckOptions
    {
        private readonly string description;

        public LiveHealthCheckOptions(string description)
        {
            this.description = description;
            ResponseWriter = async (c, r) =>
            {
                c.Response.ContentType = MediaTypeNames.Application.Json;

                var result = System.Text.Json.JsonSerializer.Serialize(new
                {
                    description = this.description,
                    r.TotalDuration,
                    date = DateTime.UtcNow,
                    Status = r.Status.ToString(),
                    Errors = r.Entries.Select(e => new { key = e.Key, value = Enum.GetName(typeof(HealthStatus), e.Value.Status), date = DateTime.UtcNow, description = e.Value.Description, e.Value.Duration })
                });
                await c.Response.WriteAsync(result);
            };

            Predicate = (r) => r.Tags.Any(t => t.Equals("LIVE", StringComparison.OrdinalIgnoreCase));
        } 
    }
}
