using System.Threading;
using System.Threading.Tasks;
using Insight.Tinkoff.Invest.Domain.Services;
using Insight.Tinkoff.Invest.Dto.Orders;
using Insight.Tinkoff.Invest.Dto.Orders.Responses;
using Insight.Tinkoff.Invest.Infrastructure;
using Insight.Tinkoff.Invest.Infrastructure.Json;
using Insight.Tinkoff.Invest.Infrastructure.Services;
using Newtonsoft.Json;

namespace Insight.Tinkoff.Invest.Services.Rest
{
    public sealed class OrderService : TinkoffRestService, IOrderService
    {
        public OrderService(TinkoffRestServiceConfiguration configuration) : base(
            configuration)
        {
        }

        public Task<EmptyResponse> Cancel(string orderId, CancellationToken cancellationToken = default)
        {
            return Post<EmptyResponse>($"{(Configuration.SandboxMode ? SandboxBasePath : BasePath)}/orders/cancel?orderId={orderId}", null,
                cancellationToken);
        }

        public Task<OrdersResponse> Get(CancellationToken cancellationToken = default)
        {
            return Get<OrdersResponse>($"{(Configuration.SandboxMode ? SandboxBasePath : BasePath)}/orders", cancellationToken);
        }

        public Task<LimitOrderResponse> PostLimitOrder(string figi, LimitOrderRequest request,
            CancellationToken cancellationToken = default)
        {
            var payload = JSerializer.Serialize(request);
            return Post<LimitOrderResponse>($"{(Configuration.SandboxMode ? SandboxBasePath : BasePath)}/orders/limit-order?figi={figi}", payload,
                cancellationToken);
        }
    }
}