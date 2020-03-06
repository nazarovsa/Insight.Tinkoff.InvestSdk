using Insight.Tinkoff.InvestSdk.Infrastructure;
using Newtonsoft.Json;

namespace Insight.Tinkoff.InvestSdk.Dto.Responses
{
    public sealed class LimitOrderResponse : ResponseBase
    {
        [JsonProperty] 
        public PlacedLimitOrder Order { get; }

        [JsonConstructor]
        public LimitOrderResponse([JsonProperty("payload")] PlacedLimitOrder limitOrder)
        {
            Order = limitOrder;
        }
    }
}