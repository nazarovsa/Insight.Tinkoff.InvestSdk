using Insight.Tinkoff.InvestSdk.Dto.Payloads;

namespace Insight.Tinkoff.InvestSdk.Dto.Messages
{
    public sealed class InstrumentInfoMessage : IWsMessage
    {
        public string Event { get; private set; }

        public InstrumentInfoPayload Payload { get; private set; }
    }
}