using Insight.Tinkoff.Invest.Infrastructure;
using Newtonsoft.Json;

namespace Insight.Tinkoff.Invest.Dto.Responses
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