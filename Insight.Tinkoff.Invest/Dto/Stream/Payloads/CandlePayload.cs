using System;
using Newtonsoft.Json;

namespace Insight.Tinkoff.Invest.Dto.Payloads
{
    public sealed class CandlePayload
    {
        [JsonConstructor]
        public CandlePayload(string figi, 
            [JsonProperty("o")] double open,
            [JsonProperty("c")] double close,
            [JsonProperty("h")] double high,
            [JsonProperty("l")] double low,
            [JsonProperty("v")] double volume,
            DateTimeOffset time,
            CandleInterval interval)
        {
            Figi = figi;
            Open = open;
            Close = close;
            High = high;
            Low = low;
            Volume = volume;
            Time = time;
            Interval = interval;
        }
        
        [JsonProperty]
        public string Figi { get; private set; }

        /// <summary>
        /// Цена открытия
        /// </summary>
        [JsonProperty]
        public double Open { get;private set; }

        /// <summary>
        /// Цена закрытия
        /// </summary>
        [JsonProperty]
        public double Close { get;private set; }

        /// <summary>
        /// Наибольшая цена
        /// </summary>
        [JsonProperty]
        public double High { get; private set; }

        /// <summary>
        /// Наименьшая цена
        /// </summary>
        [JsonProperty]
        public double Low { get;private set; }

        /// <summary>
        /// Объем торгов
        /// </summary>
        [JsonProperty]
        public double Volume { get; private set; }

        /// <summary>
        /// Время
        /// </summary>
        public DateTimeOffset Time { get; private set; }

        public CandleInterval Interval { get; private set; }
    }
}