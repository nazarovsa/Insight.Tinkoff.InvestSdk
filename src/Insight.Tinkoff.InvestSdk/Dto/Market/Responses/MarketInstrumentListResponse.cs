using System.Collections.Generic;
using Insight.Tinkoff.InvestSdk.Dto.Payloads;
using Insight.Tinkoff.InvestSdk.Infrastructure;
using Newtonsoft.Json;

namespace Insight.Tinkoff.InvestSdk.Dto.Responses
{
    public sealed class MarketInstrumentListResponse : ResponseBase
    {
        public int Total { get; }

        public IReadOnlyCollection<MarketInstrument> Instruments { get; }

        [JsonConstructor]
        public MarketInstrumentListResponse([JsonProperty("payload")] MarketInstrumentResponsePayload payload)
        {
            Total = payload.Total;
            Instruments = payload.Instruments;
        }
    }
}