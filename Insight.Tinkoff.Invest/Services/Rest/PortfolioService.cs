using System;
using System.Threading;
using System.Threading.Tasks;
using Insight.Tinkoff.Invest.Domain;
using Insight.Tinkoff.Invest.Dto.Responses;
using Insight.Tinkoff.Invest.Infrastructure.Configurations;
using Insight.Tinkoff.Invest.Infrastructure.Services;

namespace Insight.Tinkoff.Invest.Services
{
    public sealed class PortfolioService : IPortfolioService
    {
        private readonly TinkoffRestService _rest;

        public PortfolioService(RestConfiguration configuration)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));
            
            _rest = new TinkoffRestService(configuration);
        }

        public async Task<CurrenciesResponse> GetCurrencies(CancellationToken token = default)
        {
            return await _rest.Get<CurrenciesResponse>($"portfolio/currencies", token);
        }

        public async Task<PortfolioResponse> GetPortfolio(CancellationToken token = default)
        {
            return await _rest.Get<PortfolioResponse>($"portfolio", token);
        }
    }
}