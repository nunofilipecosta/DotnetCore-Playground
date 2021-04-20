using IntroMediatorCQRS.Database;
using IntroMediatorCQRS.Handlers.Products;
using Microsoft.EntityFrameworkCore;
using SimpleSoft.Mediator;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IntroMediatorCQRS.Handlers
{
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        private readonly ApiDbContext context;
        private readonly IMediator mediator;

        public CreateProductCommandHandler(ApiDbContext context, IMediator mediator)
        {
            this.context = context;
            this.mediator = mediator;
        }

        public async Task<CreateProductResult> HandleAsync(CreateProductCommand cmd, CancellationToken ct)
        {
            var products = this.context.Products;

            if (await products.AnyAsync(p => p.Code == cmd.Code, ct))
            {
                throw new InvalidOperationException($"Product code '{cmd.Code}' already exists");
            }

            var externalId = Guid.NewGuid();
            await products.AddAsync(new ProductEntity { ExternalId = externalId, Code = cmd.Code, Name = cmd.Name, Price = cmd.Price }, ct);

            await this.context.SaveChangesAsync(ct);

            await mediator.BroadcastAsync(new CreatedProductEvent
            {
                ExternalId = externalId,
                Code = cmd.Code,
                Name = cmd.Name,
                Price = cmd.Price
            }, ct);

            return new CreateProductResult { Id = externalId };
        }
    }
}
