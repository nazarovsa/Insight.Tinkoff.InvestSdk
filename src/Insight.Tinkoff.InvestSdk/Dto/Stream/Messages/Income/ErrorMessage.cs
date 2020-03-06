using Insight.Tinkoff.InvestSdk.Dto.Payloads;

namespace Insight.Tinkoff.InvestSdk.Dto.Messages
{
    public sealed class ErrorMessage : IWsMessage
    {
        public string Event { get; private set; }

        public ErrorMessagePayload Payload { get; private set; }
    }
}