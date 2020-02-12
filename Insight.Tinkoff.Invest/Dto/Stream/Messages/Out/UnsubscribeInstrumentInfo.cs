using System;

namespace Insight.Tinkoff.Invest.Dto.Messages
{
    public sealed class UnsubscribeInstrumentInfo : IWsMessage
    {
        public string Event => EventType.UnubscribeInstrumentInfo;

        public string Figi { get; private set; }

        public UnsubscribeInstrumentInfo(string figi)
        {
            if (string.IsNullOrWhiteSpace(figi))
                throw new ArgumentNullException(nameof(figi));

            Figi = figi;
        }
    }
}