using Insight.Tinkoff.Invest.Infrastructure;
using Newtonsoft.Json;

namespace Insight.Tinkoff.Invest.Dto.Responses
{
    public sealed class LimitOrderResponse : ResponseBase
    {
        public PlacedLimitOrder Order { get; }
        
        [JsonConstructor]
        public LimitOrderResponse([JsonProperty("payload")] PlacedLimitOrder limitOrder)
        {
            Order = limitOrder;
        }
    }
}