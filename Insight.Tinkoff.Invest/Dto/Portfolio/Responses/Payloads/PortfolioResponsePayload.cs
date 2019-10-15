using System.Collections.Generic;

namespace Insight.Tinkoff.Invest.Dto.Portfolio.Responses.Payloads
{
    public sealed class PortfolioResponsePayload
    {
        public IReadOnlyCollection<PortfolioPosition> Positions { get; set; }
    }
}