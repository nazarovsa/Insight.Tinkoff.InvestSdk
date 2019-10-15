using System.Collections.Generic;

namespace Insight.Tinkoff.Invest.Dto.Market.Payloads
{
    public sealed class MarketInstrumentResponsePayload 
    {
        public decimal Total { get; set; }

        public List<MarketInstrument> Instruments { get; set; }
    }
}