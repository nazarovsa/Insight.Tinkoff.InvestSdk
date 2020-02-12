using Insight.Tinkoff.Invest.Dto.Payloads;

namespace Insight.Tinkoff.Invest.Dto.Messages
{
    public sealed class InstrumentInfoMessage : IWsMessage
    {
        public string Event { get; private set; }

        public InstrumentInfoPayload Payload { get; private set; }
    }
}