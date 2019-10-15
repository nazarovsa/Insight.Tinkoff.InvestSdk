using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Insight.Tinkoff.Invest.Dto
{
    public sealed class Operation
    { 
        [DataMember(Name="id")]
        public string Id { get; set; }

        public string Figi { get; set; }

        public enum OperationStatus
        {
            /// <summary>
            /// Enum DoneEnum for Done
            /// </summary>
            [EnumMember(Value = "Done")]
            DoneEnum = 0,
            /// <summary>
            /// Enum DeclineEnum for Decline
            /// </summary>
            [EnumMember(Value = "Decline")]
            DeclineEnum = 1,
            /// <summary>
            /// Enum ProgressEnum for Progress
            /// </summary>
            [EnumMember(Value = "Progress")]
            ProgressEnum = 2
        }

        public OperationStatus? Status { get; set; }

        public List<OperationTrade> Trades { get; set; }

        public MoneyAmount Commission { get; set; }

        public string Currency { get; set; }

        public double? Payment { get; set; }

        public double? Price { get; set; }

        public int? Quantity { get; set; }

        public InstrumentType InstrumentType { get; set; }

        [DataMember(Name="isMarginCall")]
        public bool? IsMarginCall { get; set; }

        [DataMember(Name="date")]
        public DateTime? Date { get; set; }

        public enum OperationTypeWithCommission
        {
            [EnumMember(Value = "Buy")]
            BuyEnum = 0,

            [EnumMember(Value = "Sell")]
            SellEnum = 1,

            [EnumMember(Value = "BrokerCommission")]
            BrokerCommissionEnum = 2,

            [EnumMember(Value = "ExchangeCommission")]
            ExchangeCommissionEnum = 3,

            [EnumMember(Value = "ServiceCommission")]
            ServiceCommissionEnum = 4,

            [EnumMember(Value = "MarginCommission")]
            MarginCommissionEnum = 5        }

        [DataMember(Name="operationType")]
        public OperationTypeWithCommission? OperationType { get; set; }
    }
}