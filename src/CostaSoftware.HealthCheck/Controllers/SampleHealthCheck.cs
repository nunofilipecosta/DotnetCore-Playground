using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace CostaSoftware.HealthCheck.Controllers
{
    public class SampleHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var isHealthy = true;

            // ...

            if (isHealthy)
            {
                return Task.FromResult(
                    HealthCheckResult.Healthy("A healthy result."));
            }

            //return Task.FromResult(HealthCheckResult.Unhealthy())

            return Task.FromResult(
                new HealthCheckResult(
                    context.Registration.FailureStatus, "An unhealthy result."));
        }
    }

    public class SampleTypedHealthCheck : IHealthCheck
    {
        
        public SampleTypedHealthCheck(string test1, string test2)
        {

        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var isHealthy = false;

            // ...

            if (isHealthy)
            {
                return Task.FromResult(
                    HealthCheckResult.Healthy("A healthy result."));
            }


            var result = new HealthCheckResult(HealthStatus.Unhealthy, "This is a description", new ArgumentNullException("Missing argument"));
          

            return Task.FromResult(
                new HealthCheckResult(
                    context.Registration.FailureStatus, "An unhealthy result."));
        }
    }
}
