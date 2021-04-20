using SimpleSoft.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntroMediatorCQRS.Handlers.Products
{
    public class CreatedProductEvent : Event
    {
        public Guid ExternalId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
