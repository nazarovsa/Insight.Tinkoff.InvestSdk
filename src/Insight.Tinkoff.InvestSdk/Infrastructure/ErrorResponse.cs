namespace Insight.Tinkoff.InvestSdk.Infrastructure
{
    public sealed class ErrorResponse : ResponseBase
    {
        public ErrorPayload Payload { get; set; }
        
        public sealed class ErrorPayload
        {
            public string Message { get; set; }
            
            public string Code { get; set; }
        }
    }
}