using System;
using System.Threading;
using System.Threading.Tasks;
using Insight.Tinkoff.Invest.Domain;
using Insight.Tinkoff.Invest.Dto;
using Insight.Tinkoff.Invest.Dto.Responses;
using Insight.Tinkoff.Invest.Infrastructure;
using Insight.Tinkoff.Invest.Infrastructure.Configurations;
using Insight.Tinkoff.Invest.Infrastructure.Services;

namespace Insight.Tinkoff.Invest.Services
{
    public sealed class OrderService : IOrderService
    {
        private readonly TinkoffRestService _rest;

        public OrderService(RestConfiguration configuration)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            _rest = new TinkoffRestService(configuration);
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

        public Task<LimitOrderResponse> PostLimitOrder(string figi, LimitOrderRequest request,
            CancellationToken cancellationToken = default)
        {
            return _rest.Post<LimitOrderRequest, LimitOrderResponse>($"orders/limit-order?figi={figi}", request,
                cancellationToken);
        }
    }
}