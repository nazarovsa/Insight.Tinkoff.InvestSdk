using System;

namespace Insight.Tinkoff.InvestSdk.Dto.Stream
{
    public sealed class UnsubscribeOrderBookMessage : IWsMessage
    {
        public string Event => EventType.UnsubscribeOrderBook;

        public string Figi { get; private set; }

        public int Depth { get; private set; }

        public UnsubscribeOrderBookMessage(string figi, int depth)
        {
            if (string.IsNullOrWhiteSpace(figi))
                throw new ArgumentNullException(nameof(figi));

            Figi = figi;
            Depth = depth;
        }
    }
}