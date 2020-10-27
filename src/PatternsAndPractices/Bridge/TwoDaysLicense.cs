using System;

namespace PatternsAndPractices.Bridge
{

    public class TwoDaysLicense : MovieLicense
    {
        public TwoDaysLicense(string movie, DateTime purchaseTime, Discount discount) : base(movie, purchaseTime, discount)
        {
        }

        public override DateTime? GetExpirationDate()
        {
            return PurchaseTime.AddDays(2);
        }

        protected override decimal GetPriceCore()
        {
            return 4;
        }
    }

    public class TwoDaysLicense2 : MovieLicense2
    {
        public TwoDaysLicense2(string movie, DateTime purchaseTime) : base(movie, purchaseTime)
        {
        }

        public override DateTime? GetExpirationDate()
        {
            return PurchaseTime.AddDays(2);
        }

        public override decimal GetPrice()
        {
            return 4;
        }
    }

    public class MilitaryTwoDaysLicense2 : TwoDaysLicense2
    {
        public MilitaryTwoDaysLicense2(string movie, DateTime purchaseTime): base(movie, purchaseTime)
        {

        }

        public override decimal GetPrice()
        {
            return base.GetPrice() * 0.8m;
        }
    }

    public class SeniorTwoDaysLicense2 : TwoDaysLicense2
    {
        public SeniorTwoDaysLicense2(string movie, DateTime purchaseTime) : base(movie, purchaseTime)
        {

        }

        public override decimal GetPrice()
        {
            return base.GetPrice() * 0.7m;
        }
    }

}
