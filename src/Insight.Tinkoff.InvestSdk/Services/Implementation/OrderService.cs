using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Insight.Tinkoff.InvestSdk.Dto;
using Insight.Tinkoff.InvestSdk.Dto.Responses;
using Insight.Tinkoff.InvestSdk.Infrastructure;
using Insight.Tinkoff.InvestSdk.Infrastructure.Configurations;
using Insight.Tinkoff.InvestSdk.Infrastructure.Services;

namespace Insight.Tinkoff.InvestSdk.Services
{
    public sealed class OrderService : IOrderService
    {
        private readonly TinkoffRestService _rest;

        public OrderService(RestConfiguration configuration, HttpClient client = null)
        {
            _rest = new TinkoffRestService(configuration, client);
        }

        public Task<EmptyResponse> Cancel(string orderId, string brokerAccountId = null,
            CancellationToken cancellationToken = default)
        {
            return _rest.Post<object, EmptyResponse>(
                $"orders/cancel?orderId={orderId}{GetBrokerAccountIdQuery(brokerAccountId, "&")}", null,
                cancellationToken);
        }

        public Task<OrdersResponse> Get(string brokerAccountId = null, CancellationToken cancellationToken = default)
        {
            return _rest.Get<OrdersResponse>($"orders{GetBrokerAccountIdQuery(brokerAccountId, "?")}",
                cancellationToken);
        }

        public Task<LimitOrderResponse> PlaceLimitOrder(string figi,
            PlaceLimitOrderPayload payload, string brokerAccountId = null,
            CancellationToken cancellationToken = default)
        {
            return _rest.Post<PlaceLimitOrderPayload, LimitOrderResponse>(
                $"orders/limit-order?figi={figi}{GetBrokerAccountIdQuery(brokerAccountId, "&")}", payload,
                cancellationToken);
        }

        public Task<MarketOrderResponse> PlaceMarketOrder(string figi,
            PlaceMarketOrderPayload payload, string brokerAccountId = null,
            CancellationToken cancellationToken = default)
        {
            return _rest.Post<PlaceMarketOrderPayload, MarketOrderResponse>(
                $"orders/market-order?figi={figi}{GetBrokerAccountIdQuery(brokerAccountId, "&")}", payload,
                cancellationToken);
        }

        private string GetBrokerAccountIdQuery(string brokerAccountId, string firstSymbol = "")
        {
            return string.IsNullOrWhiteSpace(brokerAccountId)
                ? string.Empty
                : $"{firstSymbol}brokerAccountId={brokerAccountId}";
        }
    }
}