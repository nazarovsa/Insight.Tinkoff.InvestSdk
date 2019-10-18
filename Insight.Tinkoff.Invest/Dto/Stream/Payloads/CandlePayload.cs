using System;
using Newtonsoft.Json;

namespace Insight.Tinkoff.Invest.Dto.Payloads
{
    public sealed class CandlePayload
    {
        public string Figi { get; set; }

        /// <summary>
        /// Цена открытия
        /// </summary>
        [JsonProperty("o")]
        public double Open { get; set; }

        /// <summary>
        /// Цена закрытия
        /// </summary>
        [JsonProperty("c")]
        public double Close { get; set; }

        /// <summary>
        /// Наибольшая цена
        /// </summary>
        [JsonProperty("h")]
        public double High { get; set; }

        /// <summary>
        /// Наименьшая цена
        /// </summary>
        [JsonProperty("l")]
        public double Low { get; set; }

        /// <summary>
        /// Объем торгов
        /// </summary>
        [JsonProperty("v")]
        public double Volume { get; set; }

        /// <summary>
        /// Время
        /// </summary>
        public DateTimeOffset Time { get; set; }

        public CandleInterval Interval { get; set; }
    }
}