using System;

namespace IntroMediatorCQRS.Models
{
    public class ProductModel
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
