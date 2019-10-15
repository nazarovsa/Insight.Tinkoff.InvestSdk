using System.Threading;
using System.Threading.Tasks;
using Insight.Tinkoff.Invest.Domain;
using Insight.Tinkoff.Invest.Dto.Responses;
using Insight.Tinkoff.Invest.Infrastructure;
using Insight.Tinkoff.Invest.Infrastructure.Services;

namespace Insight.Tinkoff.Invest.Services
{
    public sealed class PortfolioService : TinkoffRestService, IPortfolioService
    {
        public PortfolioService(TinkoffRestServiceConfiguration configuration) : base(
            configuration)
        {
        }

        public async Task<CurrenciesResponse> GetCurrencies(CancellationToken token = default)
        {
            return await Get<CurrenciesResponse>($"{(Configuration.SandboxMode ? SandboxBasePath : BasePath)}/portfolio/currencies", token);
        }

        public async Task<PortfolioResponse> GetPortfolio(CancellationToken token = default)
        {
            return await Get<PortfolioResponse>($"{(Configuration.SandboxMode ? SandboxBasePath : BasePath)}/portfolio", token);
        }
    }
}