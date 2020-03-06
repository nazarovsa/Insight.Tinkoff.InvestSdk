using System.Collections.Generic;

namespace Insight.Tinkoff.InvestSdk.Dto.Responses.Payloads
{
    public sealed class CurrenciesResponsePayload
    {
        public IReadOnlyCollection<CurrencyPosition> Currencies { get; set; }
    }
}