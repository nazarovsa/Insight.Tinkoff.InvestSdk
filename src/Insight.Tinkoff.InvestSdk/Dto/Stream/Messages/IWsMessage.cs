namespace Insight.Tinkoff.InvestSdk.Dto.Stream
{
    /// <summary>
    /// Исходящее WebSocket сообщение
    /// </summary>
    public interface IWsMessage
    {
        string Event { get; }
    }

    /// <summary>
    /// Model for deserialize message from web socket
    /// </summary>
    internal sealed class WsMessage : IWsMessage
    {
        public string Event { get; set; }
    }
}