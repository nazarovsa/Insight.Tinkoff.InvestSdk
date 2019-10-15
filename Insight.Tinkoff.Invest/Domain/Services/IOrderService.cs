using System.Threading;
using System.Threading.Tasks;
using Insight.Tinkoff.Invest.Dto.Orders;
using Insight.Tinkoff.Invest.Dto.Orders.Responses;
using Insight.Tinkoff.Invest.Infrastructure;

namespace Insight.Tinkoff.Invest.Domain.Services
{
    public interface IOrderService
    {
        Task<EmptyResponse> Cancel(string orderId, CancellationToken cancellationToken = default);
        
        Task<OrdersResponse> Get(CancellationToken cancellationToken = default);

        Task<LimitOrderResponse> PostLimitOrder(string figi, LimitOrderRequest request, CancellationToken cancellationToken = default);
    }
}