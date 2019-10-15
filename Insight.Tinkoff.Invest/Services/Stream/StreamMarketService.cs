using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using Insight.Tinkoff.Invest.Domain.Services;
using Insight.Tinkoff.Invest.Dto.Stream.Messages;
using Insight.Tinkoff.Invest.Dto.Stream.Messages.Income;
using Insight.Tinkoff.Invest.Infrastructure;
using Insight.Tinkoff.Invest.Infrastructure.Json;
using Newtonsoft.Json;
using PureWebSockets;

namespace Insight.Tinkoff.Invest.Services.Stream
{
    public sealed class StreamMarketService : IStreamMarketService, IDisposable
    {
        private readonly StreamMarketServiceConfiguration _configuration;
        
        private readonly PureWebSocket _socket;
        
        private bool Disposed { get; set; }
        
        public bool OnAir { get; private set; }


        public StreamMarketService(StreamMarketServiceConfiguration configuration)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            _configuration = configuration;
            _socket = new PureWebSocket(_configuration.Address
                , new PureWebSocketOptions
                {
                    Headers = new[]
                    {
                        new Tuple<string, string>("Authorization", $"Bearer {_configuration.Token}")
                    }
                });
        }

        public async Task Send(IWsMessage message)
        {
            if (!OnAir)
                throw new InvalidOperationException("Connection is closed");

            var payload = JSerializer.Serialize(message);
            await _socket.SendAsync(payload);
        }

        public IObservable<WsMessage> AsObservable()
        {
            return Observable.FromEventPattern<Message, string>(
                    handler =>
                    {
                        Connect();

                        _socket.OnMessage += handler;
                    },
                    handler =>
                    {
                        Disconnect();

                        _socket.OnMessage -= handler;
                    })
                .Select(x => DeserializeMessage(x.EventArgs));
        }

        private void Connect(CancellationToken cancellationToken = default)
        {
            if (_socket.Connect())
                OnAir = true;
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private WsMessage DeserializeMessage(string message)
        {
            var eventType = JSerializer.Deserialize<WsMessage>(message).Event;
            switch (eventType)
            {
                case EventTypes.OrderBook:
                    return JSerializer.Deserialize<OrderBookMessage>(message);
                case EventTypes.Candle:
                    return JSerializer.Deserialize<CandleMessage>(message);
                case EventTypes.InstrumentInfo:
                    return JSerializer.Deserialize<InstrumentInfoMessage>(message);
                default:
                    throw new ArgumentException(nameof(eventType));
            }
        }

        private void Disconnect()
        {
            _socket.Disconnect();
            OnAir = false;
        }

        private void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {
                    _socket?.Dispose();
                }

                Disposed = true;
            }
        }

        ~StreamMarketService()
        {
            Dispose(false);
        }
    }

    public static class ObservableEx
    {
        private static IEnumerable<IObservable<TSource>> RepeatInfinite<TSource>(IObservable<TSource> source,
            TimeSpan dueTime)
        {
            yield return source;

            while (true)
                yield return source.DelaySubscription(dueTime);
        }

        public static IObservable<TSource> RetryAfterDelay<TSource>(this IObservable<TSource> source, TimeSpan dueTime)
        {
            return RepeatInfinite(source, dueTime).Catch();
        }
    }
}