namespace Insight.Tinkoff.Invest.Dto.Messages
{
    /// <summary>
    /// Входящее WebSocket сообщение
    /// </summary>
    public class WsMessage 
    {
        public string Event { get; set; }
    }

    public abstract class WsMessage<T> : WsMessage
    {
        public T Payload { get; set; }
    }
}