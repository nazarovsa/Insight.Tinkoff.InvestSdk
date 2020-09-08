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
        private readonly TinkoffHttpService _http;

        public SandboxService(RestConfiguration configuration,
            HttpClient client = null)
        {
            _http = new TinkoffHttpService(configuration, client);
        }

        public async Task<EmptyResponse> Register(CancellationToken cancellationToken = default)
        {
            return await _http.Post<EmptyResponse>("sandbox/register",
                null, cancellationToken: cancellationToken);
        }

        public async Task<EmptyResponse> Clear(CancellationToken cancellationToken = default)
        {
            return await _http.Post<EmptyResponse>("sandbox/clear", null,
                cancellationToken: cancellationToken);
        }

        public async Task<EmptyResponse> SetCurrencyBalance(SandboxSetCurrencyBalanceRequest request,
            CancellationToken cancellationToken = default)
        {
            return await _http.Post<EmptyResponse>(
                "sandbox/currencies/balance", request,
                cancellationToken: cancellationToken);
        }

        public async Task<EmptyResponse> SetPositionBalance(SandboxSetPositionBalanceRequest request,
            CancellationToken cancellationToken = default)
        {
            return await _http.Post<EmptyResponse>(
                "sandbox/positions/balance", request, cancellationToken: cancellationToken);
        }
    }
}