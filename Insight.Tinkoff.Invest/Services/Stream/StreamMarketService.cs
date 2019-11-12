using System;
using System.Net.WebSockets;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Insight.Tinkoff.Invest.Domain;
using Insight.Tinkoff.Invest.Dto.Messages;
using Insight.Tinkoff.Invest.Infrastructure.Configurations;
using Insight.Tinkoff.Invest.Infrastructure.Json;

namespace Insight.Tinkoff.Invest.Services
{
    public delegate void MessageReceived(object sender, string message);

    public class StreamMarketService : IStreamMarketService
    {
        private ClientWebSocket _socket;
        private readonly StreamConfiguration _configuration;

        private event MessageReceived OnMessageReceived;

        private bool Disposed { get; set; }


        public StreamMarketService(StreamConfiguration configuration)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            _configuration = configuration;
        }

        public async Task Send(IWsMessage message, CancellationToken cancellationToken = default)
        {
            await EnsureSocketConnection();

            var json = JSerializer.Serialize(message);
            var data = Encoding.UTF8.GetBytes(json);
            var buffer = new ArraySegment<byte>(data);
            await _socket.SendAsync(buffer, WebSocketMessageType.Text, true, cancellationToken);
        }

        public IObservable<WsMessage> AsObservable()
        {
            return Observable.FromEventPattern<MessageReceived, string>(
                    handler =>
                    {
                        EnsureSocketConnection().Wait();

                        OnMessageReceived += handler;
                    },
                    handler =>
                    {
                        Disconnect().Wait();

                        OnMessageReceived -= handler;
                    })
                .Select(x => DeserializeMessage(x.EventArgs));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private async Task EnsureSocketConnection()
        {
            if (_socket != null)
                return;

            if (Interlocked.CompareExchange(ref _socket, new ClientWebSocket(), null) != null)
                return;

            _socket.Options.SetRequestHeader("Authorization", $"Bearer {_configuration.AccessToken}");
            await _socket.ConnectAsync(new Uri(_configuration.Address), CancellationToken.None);

            await Receiving();
        }

        private Task Receiving()
        {
            var buffer = new byte[8192];
            Task.Run(async () =>
            {
                while (_socket.State == WebSocketState.Open)
                {
                    var result = await _socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                    if (result.MessageType == WebSocketMessageType.Text)
                    {
                        var json = Encoding.UTF8.GetString(buffer, 0, result.Count);
                        OnMessageReceived?.Invoke(this, json);
                    }
                    else if (result.MessageType == WebSocketMessageType.Close)
                    {
                        await Disconnect();
                        _socket.Dispose();
                        _socket = null;
                        break;
                    }
                }
            });

            return Task.CompletedTask;
        }

        private WsMessage DeserializeMessage(string message)
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

        private async Task Disconnect()
        {
            await _socket.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "Normal closure",
                CancellationToken.None);
        }

        private void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {
                    _socket.Dispose();
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