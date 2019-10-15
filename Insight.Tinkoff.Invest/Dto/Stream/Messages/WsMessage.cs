namespace Insight.Tinkoff.Invest.Dto.Messages
{
    public class WsMessage 
    {
        public string Event { get; set; }
    }

    public abstract class WsMessage<T> : WsMessage
    {
        public T Payload { get; set; }
    }
}