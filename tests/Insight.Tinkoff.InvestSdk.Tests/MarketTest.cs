using System;
using System.Threading;
using System.Threading.Tasks;
using Insight.Tinkoff.InvestSdk.Dto.Responses;
using Insight.Tinkoff.InvestSdk.Dto.Stream;
using Insight.Tinkoff.InvestSdk.Services;
using Insight.Tinkoff.InvestSdk.Tests.Base;
using Xunit;

namespace Insight.Tinkoff.InvestSdk.Tests
{
    public sealed class MarketTest : TestBase
    {
        private readonly IMarketService _marketService;
        private const string AccentureFigi = "BBG000D9D830";

        public MarketTest()
        {
            _marketService = new MarketService(RestConfiguration);
        }

        [Fact]
        public async Task Should_get_currencies()
        {
            var response = await _marketService.GetCurrencies(CancellationToken.None);

            ValidateRestResponse(response);
            Assert.NotNull(response.Instruments);
        }

        [Fact]
        public async Task Should_get_bonds()
        {
            var response = await _marketService.GetBonds(CancellationToken.None);

            ValidateRestResponse(response);
            ValidateInstrumentsResponse(response);
        }


        [Fact]
        public async Task Should_get_stocks()
        {
            var response = await _marketService.GetStocks(CancellationToken.None);

            ValidateRestResponse(response);
            ValidateInstrumentsResponse(response);
        }

        [Fact]
        public async Task Should_get_etfs()
        {
            var response = await _marketService.GetEtfs(CancellationToken.None);

            ValidateRestResponse(response);
            ValidateInstrumentsResponse(response);
        }

        [Fact]
        public async Task Should_get_orderbook()
        {
            var response = await _marketService.GetOrderBook(AccentureFigi, 5, CancellationToken.None);

            ValidateRestResponse(response);
            Assert.NotNull(response.OrderBook);
            Assert.False(string.IsNullOrWhiteSpace(response.OrderBook.Figi));
            Assert.Equal(5, response.OrderBook.Depth);
            Assert.NotNull(response.OrderBook.Asks);
            Assert.NotNull(response.OrderBook.Bids);
        }

        [Fact]
        public async Task Should_get_candles()
        {
            var response = await _marketService.GetCandles(AccentureFigi, DateTime.Now - TimeSpan.FromDays(1),
                DateTime.Now, CandleInterval.Hour, CancellationToken.None);

            ValidateRestResponse(response);
            Assert.False(string.IsNullOrWhiteSpace(response.Figi));
            Assert.NotNull(response.Candles);
        }

        [Fact]
        public async Task Should_search_by_ticker()
        {
            var response = await _marketService.SearchByTicker("TCS", CancellationToken.None);

            ValidateRestResponse(response);
            Assert.NotEmpty(response.Instruments);
        }

        [Fact]
        public async Task Should_search_by_figi()
        {
            var response = await _marketService.SearchByFigi(AccentureFigi, CancellationToken.None);

            ValidateRestResponse(response);
            Assert.NotEmpty(response.Instrument.Figi);
            Assert.NotEmpty(response.Instrument.Ticker);
        }

        private void ValidateInstrumentsResponse(MarketInstrumentListResponse response)
        {
            Assert.NotNull(response.Instruments);
            Assert.NotEmpty(response.Instruments);
            Assert.NotEqual(0, response.Total);
        }
    }
}