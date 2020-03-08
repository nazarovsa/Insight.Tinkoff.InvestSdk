using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Insight.Tinkoff.InvestSdk.Dto;
using Insight.Tinkoff.InvestSdk.Services;
using Insight.Tinkoff.InvestSdk.Tests.Base;
using Xunit;

namespace Insight.Tinkoff.InvestSdk.Tests
{
    public sealed class OrderTest : TestBase
    {
        private readonly IOrderService _orderService;
        private readonly ISandboxService _sandboxService;

        public OrderTest()
        {
            var client = new HttpClient();
            _orderService = new OrderService(RestConfiguration, client);
            _sandboxService = new SandboxService(RestConfiguration, client);
        }

        [Fact]
        public async Task Should_get_orders()
        {
            var response = await _orderService.Get(null, CancellationToken.None);

            ValidateRestResponse(response);
            Assert.NotNull(response.Orders);
        }

        [Fact]
        public async Task Should_place_limit_order()
        {
            var balanceSetResponse = await _sandboxService.SetCurrencyBalance(new SandboxSetCurrencyBalanceRequest
            {
                Balance = 200,
                Currency = Currency.Usd
            });

            ValidateRestResponse(balanceSetResponse);

            var request = new PlaceLimitOrderPayload
            {
                Lots = 1,
                Operation = OperationType.Buy,
                Price = 180
            };

            var response = await _orderService.PlaceLimitOrder("BBG000D9D830", request);

            ValidateRestResponse(response);
            Assert.NotNull(response.Order);
            Assert.Equal(OrderStatus.Fill, response.Order.Status);
        }

        [Fact]
        public async Task Should_place_market_order()
        {
            var balanceSetResponse = await _sandboxService.SetCurrencyBalance(new SandboxSetCurrencyBalanceRequest
            {
                Balance = 1000,
                Currency = Currency.Usd
            });

            ValidateRestResponse(balanceSetResponse);

            var request = new PlaceMarketOrderPayload
            {
                Lots = 1,
                Operation = OperationType.Buy,
            };

            var response = await _orderService.PlaceMarketOrder("BBG000D9D830", request);

            ValidateRestResponse(response);
            Assert.NotNull(response.Order);
            Assert.Equal(OrderStatus.Fill, response.Order.Status);
        }
    }
}