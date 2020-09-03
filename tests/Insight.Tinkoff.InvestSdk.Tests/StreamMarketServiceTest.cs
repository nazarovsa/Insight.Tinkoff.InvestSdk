using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Insight.Tinkoff.InvestSdk.Dto.Stream;
using Insight.Tinkoff.InvestSdk.Infrastructure.Configurations;
using Insight.Tinkoff.InvestSdk.Services;
using Insight.Tinkoff.InvestSdk.Tests.Base;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace Insight.Tinkoff.InvestSdk.Tests
{
    public sealed class StreamMarketServiceTest : TestBase
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public StreamMarketServiceTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public async Task Should_receive_messages_from_as_observable()
        {
            var obMessages = new List<OrderBookMessage>();
            var iiMessages = new List<InstrumentInfoMessage>();
            var cMessages = new List<CandleMessage>();
            using (var streamService = new StreamMarketService(new StreamConfiguration
            {
                AccessToken = Token,
                ResubscribeOnReconnect = true
            }))
            {
                var subscription = streamService
                    .AsObservable()
                    .Do(x =>
                    {
                        switch (x)
                        {
                            case OrderBookMessage m:
                                obMessages.Add(m);
                                break;
                            case InstrumentInfoMessage m:
                                iiMessages.Add(m);
                                break;
                            case CandleMessage m:
                                cMessages.Add(m);
                                break;
                            default:
                                throw new ArgumentException(nameof(x));
                        }
                    }, ex => { throw ex; })
                    .Subscribe();

                await streamService.Send(new SubscribeOrderBookMessage("BBG000D9D830", 5));
                await streamService.Send(new SubscribeInstrumentInfoMessage("BBG000D9D830"));
                await streamService.Send(new SubscribeCandleMessage("BBG000D9D830", CandleInterval.Minute));

                await Task.Delay(5 * 1000);
            }

            foreach (var orderBookMessage in obMessages)
            {
                _testOutputHelper.WriteLine(
                    $"[{DateTime.Now:HH:mm:ss.fff}]: {JsonConvert.SerializeObject(orderBookMessage)}\n");
                Assert.Equal(EventType.OrderBook, orderBookMessage.Event, StringComparer.OrdinalIgnoreCase);
                Assert.NotNull(orderBookMessage.Event);
                Assert.NotNull(orderBookMessage.Payload);
                Assert.NotNull(orderBookMessage.Payload.Asks);
                Assert.NotNull(orderBookMessage.Payload.Bids);

                if (orderBookMessage.Payload.Asks.Count != 0)
                {
                    var first = orderBookMessage.Payload.Asks.First();
                    Assert.NotEqual(default, first.Price);
                    Assert.NotEqual(default, first.Quantity);
                }
            }

            foreach (var instrumentInfoMessage in iiMessages)
            {
                _testOutputHelper.WriteLine(
                    $"[{DateTime.Now:HH:mm:ss.fff}]: {JsonConvert.SerializeObject(instrumentInfoMessage)}\n");

                Assert.Equal(EventType.InstrumentInfo, instrumentInfoMessage.Event, StringComparer.OrdinalIgnoreCase);
                Assert.NotNull(instrumentInfoMessage.Event);
                Assert.NotNull(instrumentInfoMessage.Payload);
                Assert.NotEmpty(instrumentInfoMessage.Payload.Figi);
            }

            foreach (var candleMessage in cMessages)
            {
                _testOutputHelper.WriteLine(
                    $"[{DateTime.Now:HH:mm:ss.fff}]: {JsonConvert.SerializeObject(candleMessage)}\n");
                
                Assert.Equal(EventType.Candle, candleMessage.Event, StringComparer.OrdinalIgnoreCase);
                Assert.NotNull(candleMessage.Event);
                Assert.NotNull(candleMessage.Payload);
                Assert.NotEmpty(candleMessage.Payload.Figi);
            }
        }
    }
}