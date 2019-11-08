using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Insight.Tinkoff.Invest.Dto.Payloads
{
    public class OrderBookPayload
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
                .Select(x => new LotOffer {Price = x[0], Quantity = x[1]})
                .ToList();
            Bids = bids
                .Select(x => new LotOffer {Price = x[0], Quantity = x[1]})
                .ToList();
        }

        public string Figi { get; set; }

        /// <summary>
        /// Глубина стакана
        /// </summary>
        public int Depth { get; set; }

        /// <summary>
        /// Массив предложений цены
        /// </summary>
        public IReadOnlyCollection<LotOffer> Bids { get; set; }

        /// <summary>
        /// Массив запросов цены
        /// </summary>
        public IReadOnlyCollection<LotOffer> Asks { get; set; }
    }

    public sealed class LotOffer
    {
        public decimal Price { get; set; }

        public decimal Quantity { get; set; }
    }
}