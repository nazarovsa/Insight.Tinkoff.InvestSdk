namespace Insight.Tinkoff.Invest.Dto.Stream.Messages.Out
{
    public sealed class SubscribeOrderBookMessage : IWsMessage
    {
        public string Event { get; } = "orderbook:subscribe";
        
        public string Figi { get; set; }
        
        public int Depth { get; set; }
    }
}