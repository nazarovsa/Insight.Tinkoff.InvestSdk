using System.Collections.Generic;
using System.Threading.Tasks;
using Insight.Tinkoff.InvestSdk.Dto.Stream;
using Insight.Tinkoff.InvestSdk.Infrastructure;
using Xunit;

namespace Insight.Tinkoff.InvestSdk.Tests
{
    public class SubscriptionsCollectionTest
    {
        [Fact]
        public async Task Should_push_messages()
        {
            var col = new SubscriptionsCollection();

            col.Push(new SubscribeOrderBookMessage("BBG000D9D830", 5));
            col.Push(new SubscribeOrderBookMessage("BBG000D9D830", 5));
            col.Push(new SubscribeInstrumentInfoMessage("BBG000D9D830"));
            col.Push(new SubscribeCandleMessage("BBG000D9D830", CandleInterval.Minute));

            Assert.NotEmpty(col.Subscriptions);
            Assert.Equal(3, col.Subscriptions.Count);

            col.Push(new UnsubscribeOrderBookMessage("BBG000D9D830", 5));
            col.Push(new UnsubscribeOrderBookMessage("BBG000D9D830", 5));
            col.Push(new UnsubscribeInstrumentInfoMessage("BBG000D9D830"));
            col.Push(new UnsubscribeCandleMessage("BBG000D9D830", CandleInterval.Minute));

            Assert.Empty(col.Subscriptions);

            var col2 = new SubscriptionsCollection();
            var sob1 = new List<IWsMessage>();
            for (var i = 0; i < 50; i++)
            {
                sob1.Add(new SubscribeOrderBookMessage($"figi{i}", 1));
            }

            for (var i = 0; i < 50; i++)
            {
                sob1.Add(new UnsubscribeOrderBookMessage($"figi{i}", 1));
            }

            var sc1 = new List<IWsMessage>();
            for (var i = 0; i < 50; i++)
            {
                sc1.Add(new SubscribeCandleMessage($"figi{i}", CandleInterval.Day));
            }

            for (var i = 0; i < 50; i++)
            {
                sc1.Add(new UnsubscribeCandleMessage($"figi{i}", CandleInterval.Day));
            }

            await Task.WhenAll(Task.Run(() =>
                {
                    foreach (var wsMessage in sob1)
                    {
                        col2.Push(wsMessage);
                    }
                }),
                Task.Run(() =>
                {
                    foreach (var wsMessage in sc1)
                    {
                        col2.Push(wsMessage);
                    }
                }));

            Assert.Empty(col2.Subscriptions);
        }
    }
}