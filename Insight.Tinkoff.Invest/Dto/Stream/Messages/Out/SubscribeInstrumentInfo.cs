namespace Insight.Tinkoff.Invest.Dto.Messages
{
    public sealed class SubscribeInstrumentInfo : IWsMessage
    {
        public string Event => "instrument_info:subscribe";
        
        public string Figi { get; set; }
    }
}