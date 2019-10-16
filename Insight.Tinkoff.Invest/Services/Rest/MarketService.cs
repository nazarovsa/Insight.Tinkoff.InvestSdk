using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Insight.Tinkoff.Invest.Domain;
using Insight.Tinkoff.Invest.Dto.Payloads;
using Insight.Tinkoff.Invest.Dto.Responses;
using Insight.Tinkoff.Invest.Infrastructure.Configurations;
using Insight.Tinkoff.Invest.Infrastructure.Extensions;
using Insight.Tinkoff.Invest.Infrastructure.Services;

namespace Insight.Tinkoff.Invest.Services
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

        public Task<OrderBookResponse> GetOrderBook(string figi, int depth, CancellationToken cancellationToken = default)
        {
            return Get<OrderBookResponse>($"{(Configuration.SandboxMode ? SandboxBasePath : BasePath)}/market/orderbook?figi={figi}&depth={depth}", cancellationToken);

        } 
        
        public Task<CandlesResponse> GetCandles(string figi, DateTime from, DateTime to, CandleInterval interval,
            CancellationToken cancellationToken = default)
        {
            var fromEncoded = HttpUtility.UrlEncode(from.ToString("yyyy-MM-ddTHH:mm:ss.ffffffK"));
            var toEncoded = HttpUtility.UrlEncode(to.ToString("yyyy-MM-ddTHH:mm:ss.ffffffK"));
            return Get<CandlesResponse>($"{(Configuration.SandboxMode ? SandboxBasePath : BasePath)}/market/candles?figi={figi}&from={fromEncoded}&to={toEncoded}&interval={interval.GetEnumMemberAttributeValue()}", cancellationToken);
        }
    }
}