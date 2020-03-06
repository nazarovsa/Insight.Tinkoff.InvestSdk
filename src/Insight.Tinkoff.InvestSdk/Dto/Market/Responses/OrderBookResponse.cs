using Insight.Tinkoff.InvestSdk.Dto.Payloads;
using Insight.Tinkoff.InvestSdk.Infrastructure;
using Newtonsoft.Json;

namespace Insight.Tinkoff.InvestSdk.Dto.Responses
{
    public sealed class OrderBookResponse : ResponseBase
    {
        public OrderBookRestPayload OrderBook { get; set; }

        [JsonConstructor]
        public OrderBookResponse([JsonProperty("payload")] OrderBookRestPayload payload)
        {
            OrderBook = payload;
        }
    }
}