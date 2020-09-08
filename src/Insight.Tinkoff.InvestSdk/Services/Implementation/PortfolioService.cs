using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Insight.Tinkoff.InvestSdk.Dto.Responses;
using Insight.Tinkoff.InvestSdk.Infrastructure.Configurations;
using Insight.Tinkoff.InvestSdk.Infrastructure.Services;

namespace Insight.Tinkoff.InvestSdk.Services
{
    public sealed class PortfolioService : IPortfolioService
    {
        private readonly TinkoffHttpService _http;

        public PortfolioService(RestConfiguration configuration, HttpClient client = null)
        {
            _http = new TinkoffHttpService(configuration, client);
        }

        public async Task<CurrenciesResponse> GetCurrencies(string brokerAccountId = null,
            CancellationToken cancellationToken = default)
        {
            var query = new Dictionary<string, string>();

            if (!string.IsNullOrWhiteSpace(brokerAccountId))
                query.Add("brokerAccountId", brokerAccountId);

            return await _http.Get<CurrenciesResponse>($"portfolio/currencies",
                query,
                cancellationToken: cancellationToken);
        }

        public async Task<PortfolioResponse> GetPortfolio(string brokerAccountId = null,
            CancellationToken cancellationToken = default)
        {
            var query = new Dictionary<string, string>();

            if (!string.IsNullOrWhiteSpace(brokerAccountId))
                query.Add("brokerAccountId", brokerAccountId);

            return await _http.Get<PortfolioResponse>("portfolio",
                query,
                cancellationToken: cancellationToken);
        }
    }
}