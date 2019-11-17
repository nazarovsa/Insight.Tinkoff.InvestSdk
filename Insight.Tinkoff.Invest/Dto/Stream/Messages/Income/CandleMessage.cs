using Insight.Tinkoff.Invest.Dto.Payloads;

namespace Insight.Tinkoff.Invest.Dto.Messages
{
    public sealed class CandleMessage : IWsMessage
    {
        public string Event { get; private set; }

        public CandlePayload Payload { get; private set; }
    }
}