using System.Collections.Generic;
using Insight.Tinkoff.Invest.Dto.Responses.Payloads;
using Insight.Tinkoff.Invest.Infrastructure;
using Newtonsoft.Json;

namespace Insight.Tinkoff.Invest.Dto.Responses
{
    public sealed class CurrenciesResponse : ResponseBase
    {
        public IReadOnlyCollection<CurrencyPosition> Currencies { get; }

        [JsonConstructor]
        public CurrenciesResponse([JsonProperty("payload")] CurrenciesResponsePayload payload)
        {
            Currencies = payload.Currencies;
        }
    }
}