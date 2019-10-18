namespace Insight.Tinkoff.Invest.Dto.Messages
{
    public sealed class SubscribeOrderBookMessage : IWsMessage
    {
        public string Event => EventType.SubscribeOrderBook;

        public string Figi { get; set; }

        public int Depth { get; set; }
        
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