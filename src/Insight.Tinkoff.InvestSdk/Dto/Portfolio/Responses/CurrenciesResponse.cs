using System.Collections.Generic;
using Insight.Tinkoff.InvestSdk.Dto.Payloads;
using Insight.Tinkoff.InvestSdk.Infrastructure;
using Newtonsoft.Json;

namespace Insight.Tinkoff.InvestSdk.Dto.Responses
{
    public sealed class CurrenciesResponse : ResponseBase
    {
        [JsonProperty]
        public IReadOnlyCollection<CurrencyPosition> Currencies { get; }

        [JsonConstructor]
        public CurrenciesResponse(CurrenciesResponsePayload payload)
        {
            Currencies = payload.Currencies;
        }
    }
}