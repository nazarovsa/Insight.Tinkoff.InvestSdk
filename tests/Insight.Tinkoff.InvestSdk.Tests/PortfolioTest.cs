using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Insight.Tinkoff.InvestSdk.Services;
using Insight.Tinkoff.InvestSdk.Tests.Base;
using Xunit;

namespace Insight.Tinkoff.InvestSdk.Tests
{
    public sealed class PortfolioTest : TestBase
    {
        private readonly IPortfolioService _portfolioService;
        
        public PortfolioTest()
        {
            _portfolioService = new PortfolioService(RestConfiguration, new HttpClient());
        }

        [Fact]
        public async Task Should_get_portfolio()
        {
            var response = await _portfolioService.GetPortfolio(CancellationToken.None);
            
            ValidateRestResponse(response);
            Assert.NotNull(response.Positions);
        }
        
        [Fact]
        public async Task Should_get_currencies()
        {
            var response = await _portfolioService.GetCurrencies(CancellationToken.None);
            
            ValidateRestResponse(response);
            Assert.NotNull(response.Currencies);
            Assert.NotEmpty(response.Currencies);
        }
    }
}