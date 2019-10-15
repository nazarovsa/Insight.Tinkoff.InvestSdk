using System.Collections.Generic;
using Insight.Tinkoff.Invest.Dto.Portfolio.Responses.Payloads;
using Insight.Tinkoff.Invest.Infrastructure;
using Newtonsoft.Json;

namespace Insight.Tinkoff.Invest.Dto.Portfolio.Responses
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