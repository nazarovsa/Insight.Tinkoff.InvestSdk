namespace Insight.Tinkoff.InvestSdk.Dto.Stream
{
    public sealed class OrderBookMessage : IWsMessage
    {
        public OrderBookMessage(string @event, OrderBookPayload payload)
        {
            Event = @event;
            Payload = payload;
        }

        public string Event { get; private set; }

        public OrderBookPayload Payload { get; private set; }
    }
}