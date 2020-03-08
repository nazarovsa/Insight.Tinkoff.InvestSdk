using System;
using Insight.Tinkoff.InvestSdk.Dto.Payloads;

namespace Insight.Tinkoff.InvestSdk.Dto.Messages
{
    public sealed class UnsubscribeCandleMessage : IWsMessage
    {
        public string Event => EventType.UnubscribeCandle;
        
        public string Figi { get; private set; }

        public CandleInterval Interval { get; private set; }

        public UnsubscribeCandleMessage(string figi, CandleInterval interval)
        {
            if (string.IsNullOrWhiteSpace(figi))
                throw new ArgumentNullException(nameof(figi));

            Figi = figi;
            Interval = interval;
        }
    }
}