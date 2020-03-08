using Insight.Tinkoff.InvestSdk.Infrastructure;
using Newtonsoft.Json;

namespace Insight.Tinkoff.InvestSdk.Dto.Responses
{
    public sealed class MarketOrderResponse : ResponseBase
    {
        [JsonProperty] 
        public PlacedOrder Order { get; }

        [JsonConstructor]
        public MarketOrderResponse([JsonProperty("payload")] PlacedOrder marketOrder)
        {
            Order = marketOrder;
        }
    }
}