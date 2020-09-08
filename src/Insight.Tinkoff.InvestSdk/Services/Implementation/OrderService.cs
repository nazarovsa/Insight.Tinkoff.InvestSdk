using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Insight.Tinkoff.InvestSdk.Dto.Payloads;
using Insight.Tinkoff.InvestSdk.Dto.Responses;
using Insight.Tinkoff.InvestSdk.Infrastructure;
using Insight.Tinkoff.InvestSdk.Infrastructure.Configurations;
using Insight.Tinkoff.InvestSdk.Infrastructure.Services;

namespace Insight.Tinkoff.InvestSdk.Services
{
    public sealed class OrderService : IOrderService
    {
        private readonly TinkoffHttpService _http;

        public OrderService(RestConfiguration configuration, HttpClient client = null)
        {
            _http = new TinkoffHttpService(configuration, client);
        }

        public Task<EmptyResponse> Cancel(string orderId, string brokerAccountId = null,
            CancellationToken cancellationToken = default)
        {
            var query = new Dictionary<string, string>
            {
                {"orderId", orderId}
            };

            if (!string.IsNullOrWhiteSpace(brokerAccountId))
                query.Add("brokerAccountId", brokerAccountId);

            return _http.Post<EmptyResponse>("orders/cancel",
                null,
                query,
                cancellationToken:
                cancellationToken);
        }

        public Task<OrdersResponse> Get(string brokerAccountId = null, CancellationToken cancellationToken = default)
        {
            var query = new Dictionary<string, string>();

            if (!string.IsNullOrWhiteSpace(brokerAccountId))
                query.Add("brokerAccountId", brokerAccountId);

            return _http.Get<OrdersResponse>("orders",
                query,
                cancellationToken: cancellationToken);
        }

        public Task<LimitOrderResponse> PlaceLimitOrder(string figi,
            PlaceLimitOrderPayload payload, string brokerAccountId = null,
            CancellationToken cancellationToken = default)
        {
            var query = new Dictionary<string, string>
            {
                {"figi", figi}
            };

            if (!string.IsNullOrWhiteSpace(brokerAccountId))
                query.Add("brokerAccountId", brokerAccountId);


            return _http.Post<LimitOrderResponse>($"orders/limit-order",
                payload,
                query,
                cancellationToken: cancellationToken);
        }

        public Task<MarketOrderResponse> PlaceMarketOrder(string figi,
            PlaceMarketOrderPayload payload, string brokerAccountId = null,
            CancellationToken cancellationToken = default)
        {
            var query = new Dictionary<string, string>
            {
                {"figi", figi}
            };

            if (!string.IsNullOrWhiteSpace(brokerAccountId))
                query.Add("brokerAccountId", brokerAccountId);

            return _http.Post<MarketOrderResponse>($"orders/market-order",
                payload,
                query,
                cancellationToken: cancellationToken);
        }
    }
}