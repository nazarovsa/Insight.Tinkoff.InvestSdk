namespace Insight.Tinkoff.Invest.Dto.Stream.Messages
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