using System;

namespace PatternsAndPractices.Command
{
    public interface IShoppingCartRepository
    {
        void Add(Product product);
        void RemoveAll();
        LineItem Get(Guid articleId);
        void IncreaseQuantity(Guid articleId);
        void DecreaseQuantity(Guid articleId);
    }
}