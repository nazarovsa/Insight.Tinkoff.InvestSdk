namespace Insight.Tinkoff.Invest.Dto
{
    public sealed class CurrencyPosition 
    {
        public Currency Currency { get; set; }

        public decimal Balance { get; set; }

        public decimal Blocked { get; set; }
    }
}