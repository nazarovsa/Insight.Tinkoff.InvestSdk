using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Insight.Tinkoff.Invest.Dto.Payloads
{
    public sealed class OrderBookPayload
    {
        [JsonConstructor]
        public OrderBookPayload(
            [JsonProperty("figi")] string figi,
            [JsonProperty("depth")] int depth,
            [JsonProperty("asks")] IReadOnlyCollection<List<decimal>> asks,
            [JsonProperty("bids")] IReadOnlyCollection<List<decimal>> bids)
        {
            Figi = figi;
            Depth = depth;
            Asks = asks
                .Select(x => new LotOffer {Price = x[0], Amount = x[1]})
                .ToList();
            Bids = bids
                .Select(x => new LotOffer {Price = x[0], Amount = x[1]})
                .ToList();
        }

        public string Figi { get; set; }

        /// <summary>
        /// Глубина стакана
        /// </summary>
        public int Depth { get; set; }

        /// <summary>
        /// Массив [Цена, Количество] предложений цены
        /// </summary>
        public List<LotOffer> Bids { get; set; }

        /// <summary>
        /// Массив [Цена, Количество] запросов цены
        /// </summary>
        public List<LotOffer> Asks { get; set; }

        /// <summary>
        /// Обертка над убогими массивами массивов
        /// </summary>
        public sealed class LotOffer
        {
            public decimal Price { get; set; }

            public decimal Amount { get; set; }
        }
    }
}