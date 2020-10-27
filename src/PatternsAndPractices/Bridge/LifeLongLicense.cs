using System;

namespace PatternsAndPractices.Bridge
{
    public class LifeLongLicense : MovieLicense
    {
        public LifeLongLicense(string movie, DateTime purchaseTime, Discount discount) : base(movie, purchaseTime, discount)
        {

        }

        public override DateTime? GetExpirationDate()
        {
            return null;
        }

        protected override decimal GetPriceCore()
        {
            return 8;
        }
    }

    public class LifeLongLicense2 : MovieLicense2
    {
        public LifeLongLicense2(string movie, DateTime purchaseTime) : base (movie, purchaseTime)
        {

        }

        public override DateTime? GetExpirationDate()
        {
            return null;
        }

        public override decimal GetPrice()
        {
            return 8;
        }
    }

    public class MilitaryLifeLongLicense2 : LifeLongLicense2
    {
        public MilitaryLifeLongLicense2(string movie, DateTime purchaseTime) : base(movie, purchaseTime)
        {

        }

        public override decimal GetPrice()
        {
            return base.GetPrice() * 0.8m;
        }
    }

    public class SeniorLifeLongLicense2 : LifeLongLicense2
    {
        public SeniorLifeLongLicense2(string movie, DateTime purchaseTime) : base(movie, purchaseTime)
        {

        }

        public override decimal GetPrice()
        {
            return base.GetPrice() * 0.7m;
        }
    }
}
