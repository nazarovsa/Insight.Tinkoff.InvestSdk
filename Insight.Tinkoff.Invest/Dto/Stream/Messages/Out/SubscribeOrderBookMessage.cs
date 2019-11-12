using System;

namespace Insight.Tinkoff.Invest.Dto.Messages
{
    public sealed class SubscribeOrderBookMessage : IWsMessage
    {
        public string Event => EventType.SubscribeOrderBook;

        public string Figi { get; set; }

        public int Depth { get; set; }

        public SubscribeOrderBookMessage(string figi, int depth)
        {
            if (string.IsNullOrWhiteSpace(figi))
                throw new ArgumentNullException(nameof(figi));

            Figi = figi;
            Depth = depth;
        }
        
        public override int GetHashCode()
        {
            return ((Figi != null ? Figi.GetHashCode() : 0) * 397) ^ Depth;
        }

        public override bool Equals(object obj)
        {
            return obj is SubscribeOrderBookMessage m && m.Equals(this);
        }

        private bool Equals(SubscribeOrderBookMessage other)
        {
            return other.GetHashCode() == GetHashCode();
        }
    }
}