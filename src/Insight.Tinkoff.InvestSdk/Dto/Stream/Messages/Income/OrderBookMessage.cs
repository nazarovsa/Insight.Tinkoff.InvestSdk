using Insight.Tinkoff.InvestSdk.Dto.Payloads;

namespace Insight.Tinkoff.InvestSdk.Dto.Messages
{
    public sealed class OrderBookMessage : IWsMessage
    {
        public string Event { get; private set; }

        public OrderBookPayload Payload { get; private set; }
    }
}