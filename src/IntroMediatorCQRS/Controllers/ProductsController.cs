using IntroMediatorCQRS.Handlers.Products;
using IntroMediatorCQRS.Models;
using Microsoft.AspNetCore.Mvc;
using SimpleSoft.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IntroMediatorCQRS.Controllers
{
    [Route("products")]
    public class ProductsController
    {
        private readonly IMediator mediator;

        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductModel>> SearchAsync([FromQuery] string filterQ, [FromQuery] int? skip, [FromQuery] int? take, CancellationToken ct)
        {
            var result = await this.mediator.FetchAsync(new SearchProductsQuery
            {
                FilterQ = filterQ,
                Skip = skip,
                Take = take
            }, ct);


            return result.Select(r => new ProductModel
            {
                Id = r.Id,
                Code = r.Code,
                Name = r.Name,
                Price = r.Price
            });
        }

        [HttpGet("id:guid")]
        public async Task<ProductModel> GetByIdAsync([FromRoute] Guid id, CancellationToken ct)
        {
            var result = await this.mediator.FetchAsync(new GetProductByIdQuery
            {
                ProductId = id
            }, ct);

            return new ProductModel
            {
                Id = result.Id,
                Code = result.Code,
                Name = result.Name,
                Price = result.Price
            };
        }

        [HttpPost]
        public async Task<CreateProductResultModel> CreateAsync([FromBody] CreateProductModel model, CancellationToken ct)
        {
            var result = await this.mediator.SendAsync(new CreateProductCommand { Code = model.Code, Name = model.Name, Price = model.Price }, ct);

            return new CreateProductResultModel { Id = result.Id };
        }

        [HttpPut("id:guid")]
        public async Task UpdateAsync([FromRoute] Guid id, [FromBody] UpdateProductModel model, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("id:guid")]
        public async Task DeleteAsync([FromRoute] Guid id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
