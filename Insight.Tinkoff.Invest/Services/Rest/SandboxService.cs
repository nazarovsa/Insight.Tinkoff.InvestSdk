using System.Threading;
using System.Threading.Tasks;
using Insight.Tinkoff.Invest.Domain.Services;
using Insight.Tinkoff.Invest.Dto.Sandbox;
using Insight.Tinkoff.Invest.Infrastructure;
using Insight.Tinkoff.Invest.Infrastructure.Json;
using Insight.Tinkoff.Invest.Infrastructure.Services;
using Newtonsoft.Json;

namespace Insight.Tinkoff.Invest.Services.Rest
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
            return await Post<EmptyResponse>($"{(Configuration.SandboxMode ? SandboxBasePath : BasePath)}/sandbox/register",
                null, cancellationToken);
        }

        public async Task<EmptyResponse> Clear(CancellationToken cancellationToken = default)
        {
            return await Post<EmptyResponse>($"{(Configuration.SandboxMode ? SandboxBasePath : BasePath)}/sandbox/clear", null,
                cancellationToken);
        }

        public async Task<EmptyResponse> PostCurrenciesBalance(SandboxSetCurrencyBalanceRequest request,
            CancellationToken cancellationToken = default)
        {
            var payload = JSerializer.Serialize(request);
            return await Post<EmptyResponse>(
                $"{(Configuration.SandboxMode ? SandboxBasePath : BasePath)}/sandbox/currencies/balance", payload,
                cancellationToken);
        }

        public async Task<EmptyResponse> PostPositionBalance(SandboxSetPositionBalanceRequest request,
            CancellationToken cancellationToken = default)
        {
            var payload = JSerializer.Serialize(request);
            return await Post<EmptyResponse>(
                $"{(Configuration.SandboxMode ? SandboxBasePath : BasePath)}/sandbox/positions/balance", payload,
                cancellationToken);
        }
    }
}