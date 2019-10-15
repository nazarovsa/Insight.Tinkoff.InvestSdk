using System.Threading;
using System.Threading.Tasks;
using Insight.Tinkoff.Invest.Domain.Services;
using Insight.Tinkoff.Invest.Dto.Market.Responses;
using Insight.Tinkoff.Invest.Services.Rest;
using Insight.Tinkoff.Invest.Tests.Base;
using Xunit;

namespace Insight.Tinkoff.Invest.Tests
{
    public class MarketTest : TestBase
    {
        private readonly IMarketService _marketService;
        
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

        private void ValidateInstrumentsResponse(MarketInstrumentListResponse response)
        {
            Assert.NotNull(response.Instruments);
            Assert.NotEmpty(response.Instruments);
            Assert.NotEqual(0, response.Total);
        }
    }
}