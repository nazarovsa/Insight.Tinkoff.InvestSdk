using System.Collections.Generic;
using Insight.Tinkoff.Invest.Dto.Payloads;
using Insight.Tinkoff.Invest.Infrastructure;
using Newtonsoft.Json;

namespace Insight.Tinkoff.Invest.Dto.Responses
{
    public sealed class CandlesResponse : ResponseBase
    {
        public string Figi { get; set; }
        
        public CandleInterval Interval { get; set; }
        
        public IReadOnlyCollection<CandlePayload> Candles { get; set; }
        
        [JsonConstructor]
        public CandlesResponse([JsonProperty("payload")] CandlesPayload payload)
        {
            Figi = payload.Figi;
            Interval = payload.Interval;
            Candles = payload.Candles;
        }
    }
}