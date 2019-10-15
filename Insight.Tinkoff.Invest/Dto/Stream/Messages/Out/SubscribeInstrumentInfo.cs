namespace Insight.Tinkoff.Invest.Dto.Messages
{
    public sealed class SubscribeInstrumentInfo : IWsMessage
    {
        public string Event { get; } = "instrument_info:subscribe";
        
        public string Figi { get; set; }
    }
}