using Insight.Tinkoff.Invest.Dto.Payloads;

namespace Insight.Tinkoff.Invest.Dto.Messages
{
    public sealed class UnsubscribeCandleMessage : IWsMessage
    {
        public string Event { get; } = "candle:unsubscribe";
        
        public string Figi { get; set; }
        
        public CandleInterval Interval { get; set; }
    }
}