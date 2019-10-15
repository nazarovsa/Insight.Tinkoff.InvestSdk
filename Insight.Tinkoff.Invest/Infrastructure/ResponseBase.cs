namespace Insight.Tinkoff.Invest.Infrastructure
{
    public abstract class ResponseBase
    {
        public string TrackingId { get; set; }
        
        public string Status { get; set; }
    }
}