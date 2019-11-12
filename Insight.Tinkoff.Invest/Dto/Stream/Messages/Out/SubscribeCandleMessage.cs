using System;
using Insight.Tinkoff.Invest.Dto.Payloads;

namespace Insight.Tinkoff.Invest.Dto.Messages
{
    public sealed class SubscribeCandleMessage : IWsMessage
    {
        public string Event => EventType.SubscribeCandle;

        public SubscribeCandleMessage(string figi, CandleInterval interval)
        {
            if (string.IsNullOrWhiteSpace(figi))
                throw new ArgumentNullException(nameof(figi));
            
            Figi = figi;
            Interval = interval;
        }

        public string Figi { get; private set; }

        public CandleInterval Interval { get; private set; }

        public override int GetHashCode()
        {
            return ((Figi != null ? Figi.GetHashCode() : 0) * 397) ^ (int) Interval;
        }

        public override bool Equals(object obj)
        {
            return obj is SubscribeCandleMessage m && m.Equals(this);
        }

        private bool Equals(SubscribeCandleMessage other)
        {
            return other.GetHashCode() == this.GetHashCode();
        }
    }
}