using System.Collections.Generic;

namespace Insight.Tinkoff.InvestSdk.Dto.Payloads
{
    public sealed class PortfolioResponsePayload
    {
        public IReadOnlyCollection<PortfolioPosition> Positions { get; set; }
    }
}