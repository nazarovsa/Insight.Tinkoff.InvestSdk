using System.Threading;
using System.Threading.Tasks;
using Insight.Tinkoff.Invest.Dto.Sandbox;
using Insight.Tinkoff.Invest.Infrastructure;

namespace Insight.Tinkoff.Invest.Domain.Services
{
    public interface ISandboxService
    {
        Task<EmptyResponse> Register(CancellationToken cancellationToken = default);

        Task<EmptyResponse> Clear(CancellationToken cancellationToken = default);

        Task<EmptyResponse> PostCurrenciesBalance(SandboxSetCurrencyBalanceRequest request,
            CancellationToken cancellationToken = default);
        
        Task<EmptyResponse> PostPositionBalance(SandboxSetPositionBalanceRequest request,
            CancellationToken cancellationToken = default);
    }
}