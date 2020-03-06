using System.Threading;
using System.Threading.Tasks;
using Insight.Tinkoff.InvestSdk.Dto;
using Insight.Tinkoff.InvestSdk.Infrastructure;

namespace Insight.Tinkoff.InvestSdk.Services
{
    public interface ISandboxService
    {
        Task<EmptyResponse> Register(CancellationToken cancellationToken = default);

        Task<EmptyResponse> Clear(CancellationToken cancellationToken = default);

        Task<EmptyResponse> SetCurrencyBalance(SandboxSetCurrencyBalanceRequest request,
            CancellationToken cancellationToken = default);
        
        Task<EmptyResponse> SetPositionBalance(SandboxSetPositionBalanceRequest request,
            CancellationToken cancellationToken = default);
    }
}