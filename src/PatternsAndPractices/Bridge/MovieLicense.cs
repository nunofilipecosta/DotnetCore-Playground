using System;

namespace PatternsAndPractices.Bridge
{
    public abstract class MovieLicense
    {
        private readonly Discount discount;
        public string Movie { get; }
        public DateTime PurchaseTime { get; }

        public MovieLicense(string movie, DateTime purchaseTime, Discount discount)
        {
            this.Movie = movie;
            this.PurchaseTime = purchaseTime;
            this.discount = discount;
        }

        public decimal GetPrice()
        {
            int discount = this.discount.GetDiscount();
            decimal multiplier = 1 - discount / 100m;
            return this.GetPriceCore() * multiplier;
        }

        protected abstract decimal GetPriceCore();
        public abstract DateTime? GetExpirationDate();
    }

    public abstract class MovieLicense2
    {
        public string Movie { get; }

        public DateTime PurchaseTime { get; }

        public MovieLicense2(string movie, DateTime purchaseTime)
        {
            this.Movie = movie;
            this.PurchaseTime = purchaseTime;
        }

        public abstract decimal GetPrice();
        public abstract DateTime? GetExpirationDate();
    }
}
