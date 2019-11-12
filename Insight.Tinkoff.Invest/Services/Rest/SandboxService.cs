using System;
using System.Threading;
using System.Threading.Tasks;
using Insight.Tinkoff.Invest.Domain;
using Insight.Tinkoff.Invest.Dto;
using Insight.Tinkoff.Invest.Infrastructure;
using Insight.Tinkoff.Invest.Infrastructure.Configurations;
using Insight.Tinkoff.Invest.Infrastructure.Services;

namespace Insight.Tinkoff.Invest.Services
{
    public sealed class SandboxService : ISandboxService
    {
        private readonly TinkoffRestService _rest;

        public SandboxService(
            RestConfiguration configuration)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            _rest = new TinkoffRestService(configuration);
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