using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace CostaSoftware.HealthCheck.Controllers
{
    public class SampleTypedHealthCheck : IHealthCheck
    {
        
        public SampleTypedHealthCheck(string test1, string test2)
        {

        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var randomNumber = new Random().Next(1, 10);
            var isHealthy =  randomNumber < 5 ? true : false;

            // ...

            if (isHealthy)
            {
                return Task.FromResult(
                    HealthCheckResult.Healthy($"A healthy result {randomNumber}."));
            }


            var result = new HealthCheckResult(HealthStatus.Unhealthy, "This is a description", new ArgumentNullException("Missing argument"));
          

            return Task.FromResult(
                new HealthCheckResult(
                    context.Registration.FailureStatus, $"An unhealthy result  {randomNumber}."));
        }
    }
}
