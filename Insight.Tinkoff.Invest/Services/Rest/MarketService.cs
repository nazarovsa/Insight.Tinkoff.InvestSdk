using System.Threading;
using System.Threading.Tasks;
using Insight.Tinkoff.Invest.Domain.Services;
using Insight.Tinkoff.Invest.Dto.Market.Responses;
using Insight.Tinkoff.Invest.Infrastructure;
using Insight.Tinkoff.Invest.Infrastructure.Services;

namespace Insight.Tinkoff.Invest.Services.Rest
{
    public sealed class MarketService : TinkoffRestService, IMarketService
    {
        public MarketService(TinkoffRestServiceConfiguration configuration) : base(
            configuration)
        {
        }

        public Task<MarketInstrumentListResponse> GetBonds(CancellationToken cancellationToken = default)
        {
            return Get<MarketInstrumentListResponse>($"{(Configuration.SandboxMode ? SandboxBasePath : BasePath)}/market/bonds", cancellationToken);
        }

        public Task<MarketInstrumentListResponse> GetCurrencies(CancellationToken cancellationToken = default)
        {
            return Get<MarketInstrumentListResponse>($"{(Configuration.SandboxMode ? SandboxBasePath : BasePath)}/market/currencies", cancellationToken);
        }

        public Task<MarketInstrumentListResponse> GetEtfs(CancellationToken cancellationToken = default)
        {
            return Get<MarketInstrumentListResponse>($"{(Configuration.SandboxMode ? SandboxBasePath : BasePath)}/market/etfs", cancellationToken);
        }

        public Task<MarketInstrumentListResponse> GetStocks(CancellationToken cancellationToken = default)
        {
            return Get<MarketInstrumentListResponse>($"{(Configuration.SandboxMode ? SandboxBasePath : BasePath)}/market/stocks", cancellationToken);
        }

        public Task<MarketInstrumentSearchResponse> SearchByFigi(string figi, CancellationToken cancellationToken = default)
        {
            return Get<MarketInstrumentSearchResponse>($"{(Configuration.SandboxMode ? SandboxBasePath : BasePath)}/market/search/by-figi?figi={figi}", cancellationToken);
        }

        public Task<MarketInstrumentListResponse> SearchByTicker(string ticker, CancellationToken cancellationToken = default)
        {
            return Get<MarketInstrumentListResponse>($"{(Configuration.SandboxMode ? SandboxBasePath : BasePath)}/market/search/by-ticker?ticker={ticker}", cancellationToken);
        }
    }
}