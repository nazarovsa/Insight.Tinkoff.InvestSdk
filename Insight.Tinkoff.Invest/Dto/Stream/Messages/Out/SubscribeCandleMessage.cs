using Insight.Tinkoff.Invest.Dto.Payloads;

namespace Insight.Tinkoff.Invest.Dto.Messages
{
    public sealed class SubscribeCandleMessage : IWsMessage
    {
        public string Event => "candle:subscribe";
        
        public string Figi { get; set; }
        
        public CandleInterval Interval { get; set; }
    }
}