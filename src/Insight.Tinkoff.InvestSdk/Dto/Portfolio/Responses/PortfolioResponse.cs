using System.Collections.Generic;
using Insight.Tinkoff.InvestSdk.Dto.Responses.Payloads;
using Insight.Tinkoff.InvestSdk.Infrastructure;
using Newtonsoft.Json;

namespace Insight.Tinkoff.InvestSdk.Dto.Responses
{
    public sealed class PortfolioResponse : ResponseBase
    {
        [JsonProperty]
        public IReadOnlyCollection<PortfolioPosition> Positions { get; }

        [JsonConstructor]
        public PortfolioResponse(PortfolioResponsePayload payload)
        {
            Positions = payload.Positions;
        }
    }
}