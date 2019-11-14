using Newtonsoft.Json;

namespace Insight.Tinkoff.Invest.Dto
{
    public sealed class Order
    {
        public string OrderId { get; set; }

        public string Figi { get; set; }

        public OperationType Operation { get; set; }

        public OrderStatus Status { get; set; }

        public int RequestedLots { get; set; }

        public int ExecutedLots { get; set; }

        public OrderType Type { get; set; }

        public decimal Price { get; set; }
    }
}