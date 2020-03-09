using System.Collections.Generic;
using Insight.Tinkoff.InvestSdk.Dto.Stream;

namespace Insight.Tinkoff.InvestSdk.Dto.Payloads
{
    public sealed class CandlesPayload
    {
        public string Figi { get; set; }
        
        public CandleInterval Interval { get; set; }
        
        public IReadOnlyCollection<CandlePayload> Candles { get; set; }
    }
}