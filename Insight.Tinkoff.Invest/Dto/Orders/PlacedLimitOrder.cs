using Newtonsoft.Json;

namespace Insight.Tinkoff.Invest.Dto
{
    public sealed class PlacedLimitOrder
    { 
        public string OrderId { get; set; }

        [JsonProperty("operation")]
        public OperationType OperationType { get; set; }

        public OrderStatus Status { get; set; }

        public string RejectReason { get; set; }

        public int RequestedLots { get; set; }

        public int ExecutedLots { get; set; }

        public MoneyAmount Commission { get; set; }
    }
}