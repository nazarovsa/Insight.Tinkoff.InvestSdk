namespace Insight.Tinkoff.Invest.Dto.Stream.Messages.Out
{
    public sealed class UnsubscribeInstrumentInfo : IWsMessage
    {
        public string Event { get; } = "instrument_info:unsubscribe";
        
        public string Figi { get; set; }
    }
}