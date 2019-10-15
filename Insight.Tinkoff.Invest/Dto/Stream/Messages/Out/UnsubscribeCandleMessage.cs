using Insight.Tinkoff.Invest.Dto.Stream.Payloads;

namespace Insight.Tinkoff.Invest.Dto.Stream.Messages.Out
{
    public sealed class UnsubscribeCandleMessage : IWsMessage
    {
        public string Event { get; } = "candle:unsubscribe";
        
        public string Figi { get; set; }
        
        public CandleInterval Interval { get; set; }
    }
}