namespace Insight.Tinkoff.Invest.Dto.Messages
{
    public sealed class UnsubscribeInstrumentInfo : IWsMessage
    {
        public string Event => "instrument_info:unsubscribe";
        
        public string Figi { get; set; }
    }
}