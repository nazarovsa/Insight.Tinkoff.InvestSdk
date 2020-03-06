using System.Collections.Generic;

namespace Insight.Tinkoff.InvestSdk.Dto.Payloads
{
    public sealed class CandlesPayload
    {
        public string Figi { get; set; }
        
        public CandleInterval Interval { get; set; }
        
        public IReadOnlyCollection<CandlePayload> Candles { get; set; }
    }
}