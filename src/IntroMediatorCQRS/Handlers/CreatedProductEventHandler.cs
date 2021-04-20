using IntroMediatorCQRS.Handlers.Products;
using Microsoft.Extensions.Logging;
using SimpleSoft.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IntroMediatorCQRS.Handlers
{
    public class CreatedProductEventHandler : IEventHandler<CreatedProductEvent>
    {
        private readonly ILogger<CreatedProductEventHandler> _logger;

        public CreatedProductEventHandler(ILogger<CreatedProductEventHandler> logger)
        {
            _logger = logger;
        }

        public Task HandleAsync(CreatedProductEvent evt, CancellationToken ct)
        {
            _logger.LogInformation("The product '{externalId}' has been created", evt.ExternalId);

            return Task.CompletedTask;
        }
    }
}
