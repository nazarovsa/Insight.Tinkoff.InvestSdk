using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Insight.Tinkoff.InvestSdk.Dto.Responses;
using Insight.Tinkoff.InvestSdk.Infrastructure;
using Insight.Tinkoff.InvestSdk.Infrastructure.Configurations;
using Insight.Tinkoff.InvestSdk.Infrastructure.Services;

namespace Insight.Tinkoff.InvestSdk.Services
{
    public sealed class PortfolioService : IPortfolioService
    {
        private readonly TinkoffRestService _rest;

        public PortfolioService(RestConfiguration configuration, HttpClient client = null)
        {
            _rest = new TinkoffRestService(configuration, client);
        }

        public async Task<CurrenciesResponse> GetCurrencies(string brokerAccountId = null,
            CancellationToken token = default)
        {
            return await _rest.Get<CurrenciesResponse>(
                $"portfolio/currencies{BrokerAccountIdQueryHelper.Get(brokerAccountId, "?")}", token);
        }

        public async Task<PortfolioResponse> GetPortfolio(string brokerAccountId = null,
            CancellationToken token = default)
        {
            return await _rest.Get<PortfolioResponse>(
                $"portfolio{BrokerAccountIdQueryHelper.Get(brokerAccountId, "?")}", token);
        }
    }
}