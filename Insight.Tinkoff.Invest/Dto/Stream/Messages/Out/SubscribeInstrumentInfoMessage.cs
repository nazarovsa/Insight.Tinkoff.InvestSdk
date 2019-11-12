using System;

namespace Insight.Tinkoff.Invest.Dto.Messages
{
    public sealed class SubscribeInstrumentInfoMessage : IWsMessage
    {
        public string Event => EventType.SubscribeInstrumentInfo;

        public string Figi { get; set; }

        public SubscribeInstrumentInfoMessage(string figi)
        {
            if (string.IsNullOrWhiteSpace(figi))
                throw new ArgumentNullException(nameof(figi));
            
            Figi = figi;
        }
        
        public override int GetHashCode()
        {
            return (Figi != null ? Figi.GetHashCode() : 0);
        }

        public override bool Equals(object obj)
        {
            return obj is SubscribeInstrumentInfoMessage m && m.Equals(this);
        }

        private bool Equals(SubscribeInstrumentInfoMessage other)
        {
            return string.Equals(Figi, other.Figi, StringComparison.OrdinalIgnoreCase);
        }
    }
}