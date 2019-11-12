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
    public sealed class MarketService : IMarketService
    {
        private readonly TinkoffRestService _rest;

        public MarketService(RestConfiguration configuration)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            _rest = new TinkoffRestService(configuration);
        }

        public Task<MarketInstrumentListResponse> GetBonds(CancellationToken cancellationToken = default)
        {
            return _rest.Get<MarketInstrumentListResponse>("market/bonds", cancellationToken);
        }

        public Task<MarketInstrumentListResponse> GetCurrencies(CancellationToken cancellationToken = default)
        {
            return _rest.Get<MarketInstrumentListResponse>("market/currencies", cancellationToken);
        }

        public Task<MarketInstrumentListResponse> GetEtfs(CancellationToken cancellationToken = default)
        {
            return _rest.Get<MarketInstrumentListResponse>("market/etfs", cancellationToken);
        }

        public Task<MarketInstrumentListResponse> GetStocks(CancellationToken cancellationToken = default)
        {
            return _rest.Get<MarketInstrumentListResponse>("market/stocks", cancellationToken);
        }

        public Task<MarketInstrumentSearchResponse> SearchByFigi(string figi,
            CancellationToken cancellationToken = default)
        {
            return _rest.Get<MarketInstrumentSearchResponse>($"market/search/by-figi?figi={figi}", cancellationToken);
        }

        public Task<MarketInstrumentListResponse> SearchByTicker(string ticker,
            CancellationToken cancellationToken = default)
        {
            return _rest.Get<MarketInstrumentListResponse>($"market/search/by-ticker?ticker={ticker}",
                cancellationToken);
        }

        public Task<OrderBookResponse> GetOrderBook(string figi, int depth,
            CancellationToken cancellationToken = default)
        {
            return _rest.Get<OrderBookResponse>($"market/orderbook?figi={figi}&depth={depth}", cancellationToken);
        }

        public Task<CandlesResponse> GetCandles(string figi, DateTime from, DateTime to, CandleInterval interval,
            CancellationToken cancellationToken = default)
        {
            var fromEncoded = HttpUtility.UrlEncode(from.ToString("yyyy-MM-ddTHH:mm:ss.ffffffK"));
            var toEncoded = HttpUtility.UrlEncode(to.ToString("yyyy-MM-ddTHH:mm:ss.ffffffK"));
            return _rest.Get<CandlesResponse>(
                $"market/candles?figi={figi}&from={fromEncoded}&to={toEncoded}&interval={interval.GetEnumMemberAttributeValue()}",
                cancellationToken);
        }
    }
}