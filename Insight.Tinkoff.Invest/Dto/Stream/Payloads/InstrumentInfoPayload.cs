using Newtonsoft.Json;

namespace Insight.Tinkoff.Invest.Dto.Payloads
{
    public sealed class InstrumentInfoPayload
    {
        public string Figi { get; set; }
        
        /// <summary>
        /// Статус торгов
        /// </summary>
        [JsonProperty("trade_status")]
        public TradeStatus TradeStatus { get; set; }
        
        /// <summary>
        /// Шаг цены
        /// </summary>
        [JsonProperty("min_price_increment")]
        public decimal MinPriceIncrement { get; set; }
        
        /// <summary>
        /// Лот
        /// </summary>
        public decimal Lot { get; set; }
        
        /// <summary>
        /// НКД. Возвращается только для бондов
        /// </summary>
        [JsonProperty("accrued_interest")]
        public decimal? AccruedInterest { get; set; }
        
        /// <summary>
        /// Верхняя граница заявки. Возвращается только для RTS инструментов
        /// </summary>
        [JsonProperty("limit_up")]
        public decimal? LimitUp { get; set; }
        
        /// <summary>
        /// Нижняя граница заявки. Возвращается только для RTS инструментов
        /// </summary>
        [JsonProperty("limit_down")]
        public decimal? LimitDown { get; set; }
    }
}