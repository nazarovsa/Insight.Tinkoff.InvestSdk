using System;
using System.Runtime.Serialization;

namespace Insight.Tinkoff.Invest.Dto.Operations
{
    public sealed class OperationTrade 
    {
        [DataMember(Name = "tradeId")]
        public string TradeId { get; set; }

        [DataMember(Name = "date")]
        public DateTime? Date { get; set; }

        [DataMember(Name = "price")]
        public double? Price { get; set; }

        [DataMember(Name = "quantity")]
        public int? Quantity { get; set; }
    }
}