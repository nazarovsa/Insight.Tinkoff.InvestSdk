using Insight.Tinkoff.Invest.Infrastructure;
using Newtonsoft.Json;

namespace Insight.Tinkoff.Invest.Dto.Responses
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