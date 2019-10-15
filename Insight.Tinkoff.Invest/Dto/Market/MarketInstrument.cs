namespace Insight.Tinkoff.Invest.Dto
{
    public sealed class MarketInstrument
    {
        public string Figi { get; set; }

        public string Ticker { get; set; }

        public string Isin { get; set; }

        public decimal MinPriceIncrement { get; set; }

        public int Lot { get; set; }
        
        /// <summary>
        /// Gets or Sets Currency
        /// </summary>
        public Currency Currency { get; set; }
    }
}