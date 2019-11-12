using System;

namespace Insight.Tinkoff.Invest.Dto.Messages
{
    public sealed class UnsubscribeOrderBookMessage : IWsMessage
    {
        public string Event => EventType.UnsbscribeOrderBook;

        public UnsubscribeOrderBookMessage(string figi, int depth)
        {
            if (string.IsNullOrWhiteSpace(figi))
                throw new ArgumentNullException(nameof(figi));

            Figi = figi;
            Depth = depth;
        }

        public string Figi { get; private set; }

        public int Depth { get; private set; }
    }
}