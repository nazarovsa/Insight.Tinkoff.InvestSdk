using Insight.Tinkoff.InvestSdk.Infrastructure;
using Newtonsoft.Json;

namespace Insight.Tinkoff.InvestSdk.Dto.Responses
{
    public sealed class MarketInstrumentSearchResponse : ResponseBase
    {
        public MarketInstrument Instrument { get; }

        [JsonConstructor]
        public MarketInstrumentSearchResponse([JsonProperty("payload")] MarketInstrument instrument)

        {
            Instrument = instrument;
        }
    }
}