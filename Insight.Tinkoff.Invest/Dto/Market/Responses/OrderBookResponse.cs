using Insight.Tinkoff.Invest.Dto.Payloads;
using Insight.Tinkoff.Invest.Infrastructure;
using Newtonsoft.Json;

namespace Insight.Tinkoff.Invest.Dto.Responses
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