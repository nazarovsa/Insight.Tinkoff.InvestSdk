using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Insight.Tinkoff.InvestSdk.Infrastructure.Extensions;
using Insight.Tinkoff.InvestSdk.Dto.Responses;
using Insight.Tinkoff.InvestSdk.Dto.Stream;
using Insight.Tinkoff.InvestSdk.Infrastructure.Configurations;
using Insight.Tinkoff.InvestSdk.Infrastructure.Services;

namespace Insight.Tinkoff.InvestSdk.Services
{
    public sealed class MarketService : IMarketService
    {
        private readonly TinkoffHttpService _http;

        public MarketService(RestConfiguration configuration, HttpClient client = null)
        {
            _http = new TinkoffHttpService(configuration, client);
        }

        public Task<MarketInstrumentListResponse> GetBonds(CancellationToken cancellationToken = default)
        {
            return _http.Get<MarketInstrumentListResponse>("market/bonds", cancellationToken: cancellationToken);
        }

        public Task<MarketInstrumentListResponse> GetCurrencies(CancellationToken cancellationToken = default)
        {
            return _http.Get<MarketInstrumentListResponse>("market/currencies", cancellationToken: cancellationToken);
        }

        public Task<MarketInstrumentListResponse> GetEtfs(CancellationToken cancellationToken = default)
        {
            return _http.Get<MarketInstrumentListResponse>("market/etfs", cancellationToken: cancellationToken);
        }

        public Task<MarketInstrumentListResponse> GetStocks(CancellationToken cancellationToken = default)
        {
            return _http.Get<MarketInstrumentListResponse>("market/stocks", cancellationToken: cancellationToken);
        }

        public Task<MarketInstrumentSearchResponse> SearchByFigi(string figi,
            CancellationToken cancellationToken = default)
        {
            return _http.Get<MarketInstrumentSearchResponse>("market/search/by-figi",
                new Dictionary<string, string> {{"figi", figi}},
                cancellationToken: cancellationToken);
        }

        public Task<MarketInstrumentListResponse> SearchByTicker(string ticker,
            CancellationToken cancellationToken = default)
        {
            return _http.Get<MarketInstrumentListResponse>("market/search/by-ticker",
                new Dictionary<string, string> {{"ticker", ticker}},
                cancellationToken: cancellationToken);
        }

        public Task<OrderBookResponse> GetOrderBook(string figi, int depth,
            CancellationToken cancellationToken = default)
        {
            return _http.Get<OrderBookResponse>("market/orderbook",
                new Dictionary<string, string>
                {
                    {"figi", figi},
                    {"depth", $"{depth}"}
                }, cancellationToken: cancellationToken);
        }

        public Task<CandlesResponse> GetCandles(string figi, DateTime from, DateTime to, CandleInterval interval,
            CancellationToken cancellationToken = default)
        {
            var query = new Dictionary<string, string>
            {
                {"figi", figi},
                {"from", from.ToString("yyyy-MM-ddTHH:mm:ss.ffffffK")},
                {"to", to.ToString("yyyy-MM-ddTHH:mm:ss.ffffffK")},
                {"interval", interval.GetEnumMemberAttributeValue()}
            };
            return _http.Get<CandlesResponse>($"market/candles",
                query,
                cancellationToken: cancellationToken);
        }
    }
}