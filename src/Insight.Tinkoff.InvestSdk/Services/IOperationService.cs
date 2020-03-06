using System.Threading;
using System.Threading.Tasks;
using Insight.Tinkoff.InvestSdk.Dto.Responses;
using Insight.Tinkoff.InvestSdk.Infrastructure;

namespace Insight.Tinkoff.InvestSdk.Services
{
    public interface IOperationService
    {
        Task<OperationsResponse> Get(OperationsFilter filter, CancellationToken cancellationToken = default);
    }
}