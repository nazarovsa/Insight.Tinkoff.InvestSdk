using System.Threading;
using System.Threading.Tasks;
using Insight.Tinkoff.Invest.Dto;
using Insight.Tinkoff.Invest.Dto.Responses;
using Insight.Tinkoff.Invest.Infrastructure;

namespace Insight.Tinkoff.Invest.Domain
{
    public interface IOrderService
    {
        Task<EmptyResponse> Cancel(string orderId, CancellationToken cancellationToken = default);
        
        Task<OrdersResponse> Get(CancellationToken cancellationToken = default);

        Task<LimitOrderResponse> PlaceLimitOrder(string figi, PlaceLimitOrderRequest request, CancellationToken cancellationToken = default);
    }
}