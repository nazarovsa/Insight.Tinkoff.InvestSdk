namespace Insight.Tinkoff.InvestSdk.Dto.Stream
{
    public sealed class ErrorMessage : IWsMessage
    {
        public ErrorMessage(string @event, ErrorMessagePayload payload)
        {
            Event = @event;
            Payload = payload;
        }

        public string Event { get; private set; }

        public ErrorMessagePayload Payload { get; private set; }
    }
}