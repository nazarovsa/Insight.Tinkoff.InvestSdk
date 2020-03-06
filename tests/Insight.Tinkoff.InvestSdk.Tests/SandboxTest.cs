using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Insight.Tinkoff.InvestSdk.Dto;
using Insight.Tinkoff.InvestSdk.Services;
using Insight.Tinkoff.InvestSdk.Tests.Base;
using Xunit;

namespace Insight.Tinkoff.InvestSdk.Tests
{
    public sealed class SandboxTest : TestBase
    {
        private readonly ISandboxService _sandboxService;

        public SandboxTest()
        {
            _sandboxService = new SandboxService(RestConfiguration, new HttpClient());
        }

        [Fact]
        public async Task Should_register_sandbox()
        {
            var response = await _sandboxService.Register(CancellationToken.None);
            ValidateRestResponse(response);
        }
        
        /// <summary>
        /// Uncomment fact to test. Should_post_limit_order will fail at "Run all tests" if [Fact] uncommented
        /// </summary>
        /// <returns></returns>
        // [Fact]
        public async Task Should_clear_sandbox()
        {
            var response = await _sandboxService.Clear(CancellationToken.None);
            ValidateRestResponse(response);
        }

        [Fact]
        public async Task Should_set_currency_balance()
        {
            var request = new SandboxSetCurrencyBalanceRequest()
            {
                Currency = Currency.Usd,
                Balance = 100000
            };

            var response = await _sandboxService.SetCurrencyBalance(request, CancellationToken.None);
            ValidateRestResponse(response);
        }

        [Fact]
        public async Task Should_set_position_balance()
        {
            var request = new SandboxSetPositionBalanceRequest
            {
                Figi = "BBG000D9D830",
                Balance = 1
            };

            var response = await _sandboxService.SetPositionBalance(request, CancellationToken.None);
            ValidateRestResponse(response);
        }
    }
}