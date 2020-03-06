namespace Insight.Tinkoff.InvestSdk.Dto
{
    public sealed class MarketInstrument
    {
        public string Figi { get; set; }

        public string Ticker { get; set; }

        public string Isin { get; set; }
        
        public string Name { get; set; }

        public decimal MinPriceIncrement { get; set; }

        public int Lot { get; set; }
        
        public Currency Currency { get; set; }
    }
    
    
}