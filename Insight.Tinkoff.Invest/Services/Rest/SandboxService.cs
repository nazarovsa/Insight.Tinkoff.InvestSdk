using System.Threading;
using System.Threading.Tasks;
using Insight.Tinkoff.Invest.Domain;
using Insight.Tinkoff.Invest.Dto;
using Insight.Tinkoff.Invest.Infrastructure;
using Insight.Tinkoff.Invest.Infrastructure.Configurations;
using Insight.Tinkoff.Invest.Infrastructure.Json;
using Insight.Tinkoff.Invest.Infrastructure.Services;

namespace Insight.Tinkoff.Invest.Services
{
    public sealed class SandboxService : TinkoffRestService, ISandboxService
    {
        public SandboxService(
            TinkoffRestServiceConfiguration configuration) :
            base(configuration)
        {
        }

        public async Task<EmptyResponse> Register(CancellationToken cancellationToken = default)
        {
            return await Post<object, EmptyResponse>($"{(Configuration.SandboxMode ? SandboxBasePath : BasePath)}/sandbox/register",
                null, cancellationToken);
        }

        public async Task<EmptyResponse> Clear(CancellationToken cancellationToken = default)
        {
            return await Post<object, EmptyResponse>($"{(Configuration.SandboxMode ? SandboxBasePath : BasePath)}/sandbox/clear", null,
                cancellationToken);
        }

        public async Task<EmptyResponse> SetCurrenciesBalance(SandboxSetCurrencyBalanceRequest request,
            CancellationToken cancellationToken = default)
        {
            return await Post<SandboxSetCurrencyBalanceRequest, EmptyResponse>(
                $"{(Configuration.SandboxMode ? SandboxBasePath : BasePath)}/sandbox/currencies/balance", request,
                cancellationToken);
        }

        public async Task<EmptyResponse> SetPositionBalance(SandboxSetPositionBalanceRequest request,
            CancellationToken cancellationToken = default)
        {
            return await Post<SandboxSetPositionBalanceRequest, EmptyResponse>(
                $"{(Configuration.SandboxMode ? SandboxBasePath : BasePath)}/sandbox/positions/balance", request,
                cancellationToken);
        }
    }
}