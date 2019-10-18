namespace Insight.Tinkoff.Invest.Dto.Messages
{
    public sealed class UnsubscribeOrderBookMessage : IWsMessage
    {
        public string Event => EventType.UnsbscribeOrderBook;
        
        public string Figi { get; set; }
        
        public int Depth { get; set; }
    }
}