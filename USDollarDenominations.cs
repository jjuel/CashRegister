namespace CashRegister
{
    public class USDollarDenominations
    {
        public decimal HundredDollar { get; set; }
        public decimal FiftyDollar { get; set; }
        public decimal TwentyDollar { get; set; }
        public decimal TenDollar { get; set; }
        public decimal FiveDollar { get; set; }
        public decimal OneDollar { get; set; }
        public decimal Quarter { get; set; }
        public decimal Dime { get; set; }
        public decimal Nickel { get; set; }
        public decimal Penny { get; set; }

        public USDollarDenominations()
        {
            HundredDollar = 100m;
            FiftyDollar = 50m;
            TwentyDollar = 20m;
            TenDollar = 10m;
            FiveDollar = 5m;
            OneDollar = 1m;
            Quarter = .25m;
            Dime = .10m;
            Nickel = .05m;
            Penny = .01m;
        }

        public enum DenominationNames
        {
            HundredDollars,
            FiftyDollars,
            TwentyDollars,
            TenDollars,
            FiveDollars,
            OneDollars,
            Quarters,
            Dimes,
            Nickels,
            Pennies
        }
    }    
}