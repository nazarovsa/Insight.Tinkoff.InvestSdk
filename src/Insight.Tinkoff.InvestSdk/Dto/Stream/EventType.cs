namespace Insight.Tinkoff.InvestSdk.Dto.Stream
{
    public static class EventType
    {
        public const string Error = "error";

        public const string OrderBook = "orderbook";

        public const string Candle = "candle";

        public const string InstrumentInfo = "instrument_info";

        internal const string SubscribeOrderBook = "orderbook:subscribe";

        internal const string UnsubscribeOrderBook = "orderbook:unsubscribe";

        internal const string SubscribeInstrumentInfo = "instrument_info:subscribe";

        internal const string UnsubscribeInstrumentInfo = "instrument_info:unsubscribe";

        internal const string SubscribeCandle = "candle:subscribe";

        internal const string UnsubscribeCandle = "candle:unsubscribe";
    }
}