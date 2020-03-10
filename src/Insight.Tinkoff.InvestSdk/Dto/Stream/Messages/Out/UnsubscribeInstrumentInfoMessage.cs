using System;

namespace Insight.Tinkoff.InvestSdk.Dto.Stream
{
    public sealed class UnsubscribeInstrumentInfoMessage : IWsMessage
    {
        public string Event => EventType.UnsubscribeInstrumentInfo;

        public string Figi { get; private set; }

        public UnsubscribeInstrumentInfoMessage(string figi)
        {
            if (string.IsNullOrWhiteSpace(figi))
                throw new ArgumentNullException(nameof(figi));

            Figi = figi;
        }
    }
}