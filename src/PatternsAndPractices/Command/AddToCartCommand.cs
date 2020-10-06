namespace PatternsAndPractices.Command
{
    public class AddToCartCommand : ICommand
    {
        private readonly Product product;
        private readonly IShoppingCartRepository shoppingCartRepository;
        private readonly IProductRepository productRepository;
        public AddToCartCommand(IShoppingCartRepository shoppingCartRepository, IProductRepository productRepository, Product product )
        {
            this.product = product;
            this.shoppingCartRepository = shoppingCartRepository;
            this.productRepository = productRepository;
        }

        public bool CanExecute()
        {
            if (this.product == null) return false;

            return this.productRepository.GetStockFor(product.ArticleId) > 0;
        }

        public void Execute()
        {
            if (this.product == null) return;

            this.productRepository.DecreaseStockBy(product.ArticleId, 1);
            this.shoppingCartRepository.Add(product);
        }

        public void Undo()
        {
            if (this.product == null) return;

            var lineItem = this.shoppingCartRepository.Get(product.ArticleId);
            this.productRepository.IncreaseStockBy(this.product.ArticleId, lineItem.Quantity);
            this.shoppingCartRepository.RemoveAll();
        }
    }

    public class ChangeQuantityCommand : ICommand
    {
        public enum Operation
        {
            Increase, 
            Decrease
        }


        private readonly Operation operation;
        private readonly IShoppingCartRepository shoppingCartRepository;
        private readonly IProductRepository productRepository;
        private readonly Product product;

        public ChangeQuantityCommand(Operation operation, IShoppingCartRepository shoppingCartRepository, IProductRepository productRepository, Product product)
        {
            this.operation = operation;
            this.shoppingCartRepository = shoppingCartRepository;
            this.productRepository = productRepository;
            this.product = product;
        }

        public bool CanExecute()
        {
            switch (operation)
            {
                case Operation.Increase:
                    return (productRepository.GetStockFor(product.ArticleId) - 1) >= 0;
                case Operation.Decrease:
                    return shoppingCartRepository.Get(product.ArticleId).Quantity != 0;
            }

            return false;
        }

        public void Execute()
        {
            switch (this.operation)
            {
                case Operation.Increase:
                    productRepository.DecreaseStockBy(product.ArticleId, 1);
                    shoppingCartRepository.IncreaseQuantity(product.ArticleId);
                    break;
                case Operation.Decrease:
                    productRepository.IncreaseStockBy(product.ArticleId, 1);
                    shoppingCartRepository.DecreaseQuantity(product.ArticleId);
                    break;
                default:
                    break;
            }
        }

        public void Undo()
        {
            switch (operation)
            {
                case Operation.Increase:
                    productRepository.IncreaseStockBy(product.ArticleId, 1);
                    shoppingCartRepository.DecreaseQuantity(product.ArticleId);
                    break;
                case Operation.Decrease:
                    productRepository.DecreaseStockBy(product.ArticleId, 1);
                    shoppingCartRepository.IncreaseQuantity(product.ArticleId);
                    break;
                default:
                    break;
            }
        }
    }
}
