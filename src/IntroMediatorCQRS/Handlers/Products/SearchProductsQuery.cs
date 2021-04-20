using SimpleSoft.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntroMediatorCQRS.Handlers.Products
{
    public class SearchProductsQuery : Query<IEnumerable<Product>>
    {
        public string FilterQ { get; set; }

        public int? Skip { get; set; }

        public int? Take { get; set; }
    }
}
