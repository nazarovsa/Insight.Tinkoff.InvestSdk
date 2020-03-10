using System.Collections.Generic;
using Insight.Tinkoff.InvestSdk.Dto.Stream;
using Newtonsoft.Json;

namespace Insight.Tinkoff.InvestSdk.Dto.Payloads
{
    public sealed class OrderBookRestPayload
    {
        [JsonConstructor]
        public OrderBookRestPayload([JsonProperty("figi")] string figi,
            [JsonProperty("depth")] int depth,
            [JsonProperty("asks")] IReadOnlyCollection<LotOffer> asks,
            [JsonProperty("bids")] IReadOnlyCollection<LotOffer> bids,
            [JsonProperty("lastPrice")] decimal lastPrice,
            [JsonProperty("closePrice")] decimal closePrice,
            [JsonProperty("limitUp")] decimal limitUp,
            [JsonProperty("limitDown")] decimal limitDown,
            [JsonProperty("tradeStatus")] Stream.TradeStatus tradeStatus)
        {
            Figi = figi;
            Depth = depth;
            Asks = asks;
            Bids = bids;
            LastPrice = lastPrice;
            ClosePrice = closePrice;
            LimitUp = limitUp;
            LimitDown = limitDown;
            TradeStatus = tradeStatus;
        }
        
        public string Figi { get; set; }
        
        public Stream.TradeStatus TradeStatus { get; set; }

        /// <summary>
        /// Глубина стакана
        /// </summary>
        public int Depth { get; set; }

        /// <summary>
        /// Массив [Цена, Количество] предложений цены
        /// </summary>
        public IReadOnlyCollection<LotOffer> Bids { get; set; }

        /// <summary>
        /// Массив [Цена, Количество] запросов цены
        /// </summary>
        public IReadOnlyCollection<LotOffer> Asks { get; set; }
        
        public decimal MinPriceIncrement { get; set; }
        
        public decimal LastPrice { get; set; }
        
        public decimal ClosePrice { get; set; }
        
        public decimal LimitUp { get; set; }
        
        public decimal LimitDown { get; set; }
    }
}