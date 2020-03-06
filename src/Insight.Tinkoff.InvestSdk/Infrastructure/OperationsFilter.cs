using System;
using Insight.Tinkoff.InvestSdk.Dto;

namespace Insight.Tinkoff.InvestSdk.Infrastructure
{
    public class OperationsFilter
    {
        public DateTime From { get; set; } = DateTime.Now - TimeSpan.FromHours(1);
        
        public DateTime To { get; set; } = DateTime.Now;

        public string Figi { get; set; }

        public OperationInterval Interval { get; set; }
    }
}