using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Insight.Tinkoff.InvestSdk.Dto;
using Insight.Tinkoff.InvestSdk.Infrastructure;
using Insight.Tinkoff.InvestSdk.Infrastructure.Configurations;
using Insight.Tinkoff.InvestSdk.Infrastructure.Services;

namespace Insight.Tinkoff.InvestSdk.Services
{
    public sealed class SandboxService : ISandboxService
    {
        private readonly TinkoffRestService _rest;

        public SandboxService(RestConfiguration configuration,
            HttpClient client = null)
        {
            _rest = new TinkoffRestService(configuration, client);
        }

        public async Task<EmptyResponse> Register(CancellationToken cancellationToken = default)
        {
            return await _rest.Post<object, EmptyResponse>($"sandbox/register",
                null, cancellationToken);
        }

        public async Task<EmptyResponse> Clear(CancellationToken cancellationToken = default)
        {
            return await _rest.Post<object, EmptyResponse>("sandbox/clear", null,
                cancellationToken);
        }

        public async Task<EmptyResponse> SetCurrencyBalance(SandboxSetCurrencyBalanceRequest request,
            CancellationToken cancellationToken = default)
        {
            return await _rest.Post<SandboxSetCurrencyBalanceRequest, EmptyResponse>(
                "sandbox/currencies/balance", request,
                cancellationToken);
        }

        public async Task<EmptyResponse> SetPositionBalance(SandboxSetPositionBalanceRequest request,
            CancellationToken cancellationToken = default)
        {
            return await _rest.Post<SandboxSetPositionBalanceRequest, EmptyResponse>(
                "sandbox/positions/balance", request,
                cancellationToken);
        }
    }
}