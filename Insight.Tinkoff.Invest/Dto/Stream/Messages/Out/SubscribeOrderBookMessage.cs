namespace Insight.Tinkoff.Invest.Dto.Messages
{
    public sealed class SubscribeOrderBookMessage : IWsMessage
    {
        public string Event { get; } = "orderbook:subscribe";
        
        public string Figi { get; set; }
        
        public int Depth { get; set; }
    }
}