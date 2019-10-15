using Insight.Tinkoff.Invest.Dto.Stream.Payloads;

namespace Insight.Tinkoff.Invest.Dto.Stream.Messages.Out
{
    public sealed class SubscribeCandleMessage : IWsMessage
    {
        public string Event { get; } = "candle:subscribe";
        
        public string Figi { get; set; }
        
        public CandleInterval Interval { get; set; }
    }
}