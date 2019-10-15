namespace Insight.Tinkoff.Invest.Dto.Messages
{
    public sealed class UnsubscribeOrderBookMessage : IWsMessage
    {
        public string Event => "orderbook:unsubscribe";
        
        public string Figi { get; set; }
        
        public int Depth { get; set; }
    }
}