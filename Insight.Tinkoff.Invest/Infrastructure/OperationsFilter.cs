using System;
using Insight.Tinkoff.Invest.Dto.Operations;

namespace Insight.Tinkoff.Invest.Infrastructure
{
    public class OperationsFilter
    {
        public DateTime From { get; set; } = DateTime.Now;

        public string Figi { get; set; }

        public OperationInterval Interval { get; set; }
    }
}