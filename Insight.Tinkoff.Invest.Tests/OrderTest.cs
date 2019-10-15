using System.Threading;
using System.Threading.Tasks;
using Insight.Tinkoff.Invest.Domain.Services;
using Insight.Tinkoff.Invest.Dto.Orders;
using Insight.Tinkoff.Invest.Dto.Portfolio;
using Insight.Tinkoff.Invest.Dto.Sandbox;
using Insight.Tinkoff.Invest.Services.Rest;
using Insight.Tinkoff.Invest.Tests.Base;
using Xunit;

namespace Insight.Tinkoff.Invest.Tests
{
    public class OrderTest : TestBase
    {
        private readonly IOrderService _orderService;
        private readonly ISandboxService _sandboxService;

        public OrderTest()
        {
            _orderService = new OrderService(RestConfiguration);
            _sandboxService = new SandboxService(RestConfiguration);
        }

        [Fact]
        public async Task Should_get_orders()
        {
            var response = await _orderService.Get(CancellationToken.None);

            ValidateRestResponse(response);
            Assert.NotNull(response.Orders);
        }

        [Fact]
        public async Task Should_post_limit_order()
        {
            var balanceSetResponse = await _sandboxService.PostCurrenciesBalance(new SandboxSetCurrencyBalanceRequest
            {
                Balance = 200,
                Currency = Currency.Usd
            });
            
            ValidateRestResponse(balanceSetResponse);
            
            var request = new LimitOrderRequest
            {
                Lots = 1,
                Operation = OperationType.Buy,
                Price = 180
            };
            
            var response = await _orderService.PostLimitOrder("BBG000D9D830", request, CancellationToken.None);

            ValidateRestResponse(response);
            Assert.NotNull(response.Order);
            Assert.Equal(OrderStatus.Fill, response.Order.Status);
        }
    }
}