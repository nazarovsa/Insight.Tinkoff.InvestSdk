using Insight.Tinkoff.Invest.Dto.Payloads;

namespace Insight.Tinkoff.Invest.Dto.Messages
{
    public sealed class ErrorMessage : IWsMessage
    {
        public string Event { get; private set; }

        public ErrorMessagePayload Payload { get; private set; }
    }
}