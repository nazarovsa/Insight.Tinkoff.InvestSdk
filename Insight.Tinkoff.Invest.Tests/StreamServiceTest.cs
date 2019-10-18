using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Insight.Tinkoff.Invest.Domain;
using Insight.Tinkoff.Invest.Dto.Messages;
using Insight.Tinkoff.Invest.Infrastructure.Configurations;
using Insight.Tinkoff.Invest.Infrastructure.Extensions;
using Insight.Tinkoff.Invest.Services;
using Insight.Tinkoff.Invest.Tests.Base;
using Xunit;
using Xunit.Abstractions;

namespace Insight.Tinkoff.Invest.Tests
{
    public class StreamServiceTest : TestBase
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private IStreamMarketService _streamService;

        public StreamServiceTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _streamService = new StreamMarketService(new StreamMarketServiceConfiguration
            {
                Token = Token
            });
        }

        [Fact]
        public async Task Should_receive_messages_from_as_observable()
        {
            var subscription = _streamService
                .AsObservable()
                .Do(x =>
                {
                    Assert.NotNull(x);
                    Assert.Equal("orderbook", x.Event, StringComparer.OrdinalIgnoreCase);
                    switch (x)
                    {
                        case OrderBookMessage m:
                            _testOutputHelper.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}]: type: {m.Event}, figi: {m.Payload.Figi}");
                            break;
                        default:
                            throw new ArgumentException(nameof(x));
                    }
                }, ex => { throw ex; })
                .RetryAfterDelay(TimeSpan.FromSeconds(1))
                .Subscribe();

            await _streamService.Send(new SubscribeOrderBookMessage
            {
                Figi = "BBG000D9D830",
                Depth = 5
            });

            await Task.Delay(5 * 1000);
        }
    }
}