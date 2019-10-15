namespace Insight.Tinkoff.Invest.Infrastructure
{
    public sealed class StreamMarketServiceConfiguration
    {
        public string Address { get; set; } = "wss://api-invest.tinkoff.ru/openapi/md/v1/md-openapi/ws";

        public string Token { get; set; }
    }
}