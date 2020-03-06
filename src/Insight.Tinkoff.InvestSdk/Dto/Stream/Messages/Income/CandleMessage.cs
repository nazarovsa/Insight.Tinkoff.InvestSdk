using Insight.Tinkoff.InvestSdk.Dto.Payloads;

namespace Insight.Tinkoff.InvestSdk.Dto.Messages
{
    public sealed class CandleMessage : IWsMessage
    {
        public string Event { get; private set; }

        public CandlePayload Payload { get; private set; }
    }
}