using System.Collections.Generic;

namespace Insight.Tinkoff.Invest.Dto.Portfolio.Responses.Payloads
{
    public sealed class CurrenciesResponsePayload
    {
        public IReadOnlyCollection<CurrencyPosition> Currencies { get; set; }
    }
}