namespace Insight.Tinkoff.Invest.Dto
{
    public sealed class CurrencyPosition 
    {
        public Currency Currency { get; set; }

        public double Balance { get; set; }

        public double Blocked { get; set; }
    }
}