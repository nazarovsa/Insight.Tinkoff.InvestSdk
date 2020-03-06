using System.Collections.Generic;

namespace Insight.Tinkoff.InvestSdk.Dto.Responses.Payloads
{
    public sealed class PortfolioResponsePayload
    {
        public IReadOnlyCollection<PortfolioPosition> Positions { get; set; }
    }
}