using System.Threading;
using System.Threading.Tasks;
using Insight.Tinkoff.InvestSdk.Dto;
using Insight.Tinkoff.InvestSdk.Dto.Responses;
using Insight.Tinkoff.InvestSdk.Infrastructure;

namespace Insight.Tinkoff.InvestSdk.Services
{
    public interface IOrderService
    {
        Task<EmptyResponse> Cancel(string orderId, CancellationToken cancellationToken = default);
        
        Task<OrdersResponse> Get(CancellationToken cancellationToken = default);

        Task<LimitOrderResponse> PlaceLimitOrder(string figi, PlaceLimitOrderRequest request, CancellationToken cancellationToken = default);
    }
}