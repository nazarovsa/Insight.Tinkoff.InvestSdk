using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Insight.Tinkoff.Invest.Dto.Payloads
{
    public class OrderBookPayload
    {
        [JsonConstructor]
        public OrderBookPayload(
            string figi,
            int depth,
            IReadOnlyCollection<List<decimal>> asks,
            IReadOnlyCollection<List<decimal>> bids)
        {
            Figi = figi;
            Depth = depth;
            Asks = asks
                .Select(x => new LotOffer(x[0], x[1]))
                .ToList();
            Bids = bids
                .Select(x => new LotOffer(x[0], x[1]))
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
        public LotOffer(decimal price, decimal quantity)
        {
            if (quantity == 0)
                throw new ArgumentException("Quantity can not be 0");

            Price = price;
            Quantity = quantity;
        }

        public decimal Price { get; private set; }

        public decimal Quantity { get; private set; }
    }
}