namespace Insight.Tinkoff.InvestSdk.Dto.Stream
{
    public sealed class InstrumentInfoMessage : IWsMessage
    {
        public InstrumentInfoMessage(string @event, InstrumentInfoPayload payload)
        {
            Event = @event;
            Payload = payload;
        }

        public string Event { get; private set; }

        public InstrumentInfoPayload Payload { get; private set; }
    }
}