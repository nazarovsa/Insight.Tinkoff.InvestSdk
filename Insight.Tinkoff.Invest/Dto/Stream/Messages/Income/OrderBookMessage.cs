using Insight.Tinkoff.Invest.Dto.Payloads;

namespace Insight.Tinkoff.Invest.Dto.Messages
{
    public sealed class OrderBookMessage : IWsMessage
    {
        public string Event { get; private set; }

        public OrderBookPayload Payload { get; private set; }
    }
}