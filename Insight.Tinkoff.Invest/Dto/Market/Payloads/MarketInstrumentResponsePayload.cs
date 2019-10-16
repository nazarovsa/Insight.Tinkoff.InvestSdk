using System.Collections.Generic;

namespace Insight.Tinkoff.Invest.Dto.Payloads
{
    public sealed class MarketInstrumentResponsePayload 
    {
        public int Total { get; set; }

        public List<MarketInstrument> Instruments { get; set; }
    }
}