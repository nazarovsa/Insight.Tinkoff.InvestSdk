namespace Insight.Tinkoff.InvestSdk.Dto.Stream
{
    public sealed class CandleMessage : IWsMessage
    {
        public CandleMessage(string @event, CandlePayload payload)
        {
            Event = @event;
            Payload = payload;
        }

        public string Event { get; private set; }

        public CandlePayload Payload { get; private set; }
    }
}