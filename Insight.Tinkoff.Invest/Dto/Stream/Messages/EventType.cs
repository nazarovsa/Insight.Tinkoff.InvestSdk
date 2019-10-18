namespace Insight.Tinkoff.Invest.Dto.Messages
{
    internal static class EventType
    {
        public const string Error = "error";

        public const string OrderBook = "orderbook";

        public const string Candle = "candle";

        public const string InstrumentInfo = "instrument_info";

        public const string SubscribeOrderBook = "orderbook:subscribe";

        public const string UnsbscribeOrderBook = "orderbook:unsubscribe";

        public const string SubscribeInstrumentInfo = "instrument_info:subscribe";

        public const string UnubscribeInstrumentInfo = "instrument_info:unsubscribe";

        public const string SubscribeCandle = "candle:subscribe";

        public const string UnubscribeCandle = "candle:unsubscribe";
    }
}