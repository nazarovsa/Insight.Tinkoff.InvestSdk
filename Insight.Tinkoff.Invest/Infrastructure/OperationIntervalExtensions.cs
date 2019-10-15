using System;
using Insight.Tinkoff.Invest.Dto;

namespace Insight.Tinkoff.Invest.Infrastructure
{
    public static class OperationIntervalExtensions
    {
        public static string ToParamString(this OperationInterval interval)
        {
            switch (interval)
            {
                case OperationInterval.Day:
                    return "1day";
                case OperationInterval.Week:
                    return "7days";
                case OperationInterval.TwoWeeks:
                    return "14days";
                case OperationInterval.Month:
                    return "30days";
                default:
                    throw new ArgumentOutOfRangeException(nameof(interval), interval, null);
            }
        }
    }
}