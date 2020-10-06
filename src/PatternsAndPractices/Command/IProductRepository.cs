using System;

namespace PatternsAndPractices.Command
{
    public interface IProductRepository
    {
        void DecreaseStockBy(Guid articleId, int quantity);
        int GetStockFor(Guid articleId);
        void IncreaseStockBy(Guid articleId, object quantity);
    }
}