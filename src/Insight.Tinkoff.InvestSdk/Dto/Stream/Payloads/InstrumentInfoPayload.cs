using Newtonsoft.Json;

namespace Insight.Tinkoff.InvestSdk.Dto.Stream
{
    public sealed class InstrumentInfoPayload
    {
        [JsonConstructor]
        public InstrumentInfoPayload(
            string figi,
            [JsonProperty("trade_status")] Enums.TradeStatus tradeStatus,
            [JsonProperty("min_price_increment")] decimal minPriceIncrement,
            decimal lot,
            [JsonProperty("accrued_interest")] decimal? accruedInterest,
            [JsonProperty("limit_up")] decimal? limitUp,
            [JsonProperty("limit_down")] decimal? limitDown)
        {
            Figi = figi;
            TradeStatus = tradeStatus;
            MinPriceIncrement = minPriceIncrement;
            Lot = lot;
            AccruedInterest = accruedInterest;
            LimitUp = limitUp;
            LimitDown = limitDown;
        }

        /// <summary>
        /// Figi
        /// </summary>
        public string Figi { get; private set; }

        /// <summary>
        /// Статус торгов
        /// </summary>
        [JsonProperty]
        public Enums.TradeStatus TradeStatus { get; private set; }

        /// <summary>
        /// Шаг цены
        /// </summary>
        [JsonProperty]
        public decimal MinPriceIncrement { get; private set; }

        /// <summary>
        /// Лот
        /// </summary>
        public decimal Lot { get; private set; }

        /// <summary>
        /// НКД. Возвращается только для бондов
        /// </summary>
        [JsonProperty]
        public decimal? AccruedInterest { get; private set; }

        /// <summary>
        /// Верхняя граница заявки. Возвращается только для RTS инструментов
        /// </summary>
        [JsonProperty]
        public decimal? LimitUp { get; private set; }

        /// <summary>
        /// Нижняя граница заявки. Возвращается только для RTS инструментов
        /// </summary>
        [JsonProperty]
        public decimal? LimitDown { get; private set; }
    }
}