using System.Threading;
using System.Threading.Tasks;
using Insight.Tinkoff.Invest.Dto.Responses;
using Insight.Tinkoff.Invest.Infrastructure;

namespace Insight.Tinkoff.Invest.Domain
{
    public interface IOperationService
    {
        Task<OperationsResponse> Get(OperationsFilter filter, CancellationToken cancellationToken = default);
    }
}