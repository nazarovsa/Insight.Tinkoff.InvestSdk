namespace Insight.Tinkoff.Invest.Dto.Messages
{
    public sealed class UnsubscribeInstrumentInfo : IWsMessage
    {
        public string Event => EventType.UnubscribeInstrumentInfo;

        public string Figi { get; set; }
    }
}