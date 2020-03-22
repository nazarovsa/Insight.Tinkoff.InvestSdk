using System;
using System.Net.WebSockets;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using Insight.Tinkoff.InvestSdk.Dto.Stream;
using Insight.Tinkoff.InvestSdk.Infrastructure.Configurations;
using Insight.Tinkoff.InvestSdk.Infrastructure.Json;
using Websocket.Client;

namespace Insight.Tinkoff.InvestSdk.Services
{
    public sealed class StreamMarketService : IStreamMarketService, IDisposable
    {
        private WebsocketClient _client;

        private bool Disposed { get; set; }

        private readonly StreamConfiguration _configuration;

        private readonly SubscriptionsCollection _subscriptions;

        private IDisposable _reconnectionHandler;

        public StreamMarketService(StreamConfiguration configuration)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            _configuration = configuration;

            if (_configuration.ReconnectEnabled && _configuration.ResubscribeOnReconnect)
                _subscriptions = new SubscriptionsCollection();
        }


        public async Task Send(IWsMessage message, CancellationToken cancellationToken = default)
        {
            await EnsureSocketConnection();

            await Task.Run(() => _client.Send(JSerializer.Serialize(message)), cancellationToken);

            if (_configuration.ReconnectEnabled && _configuration.ResubscribeOnReconnect)
                _subscriptions.Push(message);
        }

        public IObservable<IWsMessage> AsObservable()
        {
            EnsureSocketConnection().Wait();

            return _client.MessageReceived
                .Select(x => DeserializeMessage(x.Text));
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private async Task EnsureSocketConnection()
        {
            if (_client != null)
                return;

            var exchange = Interlocked.CompareExchange(ref _client,
                new WebsocketClient(new Uri(_configuration.Address),
                    () =>
                    {
                        var clientWebSocket = new ClientWebSocket();
                        clientWebSocket.Options.SetRequestHeader("Authorization",
                            $"Bearer {_configuration.AccessToken}");
                        return clientWebSocket;
                    })
                {
                    IsReconnectionEnabled = _configuration.ReconnectEnabled,
                    ReconnectTimeout = _configuration.ReconnectTimeout,
                    ErrorReconnectTimeout = _configuration.ErrorReconnectTimeout
                }, null);
            if (exchange != null)
                return;

            await _client.Start();

            if (_configuration.ReconnectEnabled && _configuration.ResubscribeOnReconnect)
                _reconnectionHandler = _client.ReconnectionHappened.Subscribe(x =>
                {
                    foreach (var subscription in _subscriptions.Subscriptions)
                    {
                        Send(subscription).Wait();
                    }
                });
        }

        private IWsMessage DeserializeMessage(string message)
        {
            var eventType = JSerializer.Deserialize<WsMessage>(message).Event;
            switch (eventType)
            {
                case EventType.OrderBook:
                    return JSerializer.Deserialize<OrderBookMessage>(message);
                case EventType.Candle:
                    return JSerializer.Deserialize<CandleMessage>(message);
                case EventType.InstrumentInfo:
                    return JSerializer.Deserialize<InstrumentInfoMessage>(message);
                case EventType.Error:
                    return JSerializer.Deserialize<ErrorMessage>(message);
                default:
                    throw new ArgumentException(nameof(eventType));
            }
        }

        private void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {
                    _reconnectionHandler.Dispose();
                    _client.Dispose();
                }

                Disposed = true;
            }
        }

        ~StreamMarketService()
        {
            Dispose(false);
        }
    }
}