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

        public Task<EmptyResponse> Cancel(string orderId, CancellationToken cancellationToken = default)
        {
            return _rest.Post<object, EmptyResponse>($"orders/cancel?orderId={orderId}", null,
                cancellationToken);
        }

        public Task<OrdersResponse> Get(CancellationToken cancellationToken = default)
        {
            return _rest.Get<OrdersResponse>("orders", cancellationToken);
        }

        public Task<LimitOrderResponse> PlaceLimitOrder(string figi, PlaceLimitOrderRequest request,
            CancellationToken cancellationToken = default)
        {
            return _rest.Post<PlaceLimitOrderRequest, LimitOrderResponse>($"orders/limit-order?figi={figi}", request,
                cancellationToken);
        }
    }
}