using Newtonsoft.Json;

namespace Insight.Tinkoff.Invest.Dto.Orders
{
    public sealed class Order
    {
        public string OrderId { get; set; }

        public string Figi { get; set; }

        /// <summary>
        /// operation type
        /// </summary>
        [JsonProperty("operation")]
        public OperationType OperationType { get; set; }

        /// <summary>
        /// OrderStatus
        /// </summary>
        public OrderStatus Status { get; set; }

        public int RequestedLots { get; set; }

        public int ExecutedLots { get; set; }

        public OrderType Type { get; set; }

        public decimal Price { get; set; }
    }
}