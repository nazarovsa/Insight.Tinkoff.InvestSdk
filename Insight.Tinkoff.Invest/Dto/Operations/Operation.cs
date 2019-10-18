using System;
using System.Collections.Generic;

namespace Insight.Tinkoff.Invest.Dto
{
    public sealed class Operation
    { 
        public string Id { get; set; }

        public string Figi { get; set; }

        public OperationStatus Status { get; set; }

        public IReadOnlyCollection<Trade> Trades { get; set; }

        public MoneyAmount Commission { get; set; }

        public string Currency { get; set; }

        public decimal Payment { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public InstrumentType InstrumentType { get; set; }

        public bool IsMarginCall { get; set; }

        public DateTime Date { get; set; }

        public ExtendedOperationType OperationType { get; set; }
    }
}