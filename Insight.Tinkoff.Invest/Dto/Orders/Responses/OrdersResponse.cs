using System.Collections.Generic;
using Insight.Tinkoff.Invest.Infrastructure;
using Newtonsoft.Json;

namespace Insight.Tinkoff.Invest.Dto.Responses
{
    public sealed class OrdersResponse : ResponseBase
    {
        [JsonProperty]
        public IReadOnlyCollection<Order> Orders { get; }

        [JsonConstructor]
        public OrdersResponse([JsonProperty("payload")] IReadOnlyCollection<Order> orders)
        {
            Orders = orders;
        }
    }
}