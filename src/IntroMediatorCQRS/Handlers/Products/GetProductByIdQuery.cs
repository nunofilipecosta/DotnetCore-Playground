using SimpleSoft.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntroMediatorCQRS.Handlers.Products
{
    public class GetProductByIdQuery : Query<Product>
    {
        public Guid ProductId { get; set; }
    }
}
