using System.Threading;
using System.Threading.Tasks;
using Insight.Tinkoff.InvestSdk.Dto.Payloads;
using Insight.Tinkoff.InvestSdk.Dto.Responses;
using Insight.Tinkoff.InvestSdk.Infrastructure;

namespace Insight.Tinkoff.InvestSdk.Services
{
    public interface IOrderService
    {
        Task<EmptyResponse> Cancel(string orderId, string brokerAccountId = null,
            CancellationToken cancellationToken = default);

        Task<OrdersResponse> Get(string brokerAccountId = null,
            CancellationToken cancellationToken = default);

        Task<LimitOrderResponse> PlaceLimitOrder(string figi,
            PlaceLimitOrderPayload payload,
            string brokerAccountId = null,
            CancellationToken cancellationToken = default);

        Task<MarketOrderResponse> PlaceMarketOrder(string figi,
            PlaceMarketOrderPayload payload,
            string brokerAccountId = null,
            CancellationToken cancellationToken = default);
    }
}