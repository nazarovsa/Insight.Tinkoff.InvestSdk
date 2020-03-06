namespace Insight.Tinkoff.InvestSdk.Infrastructure.Configurations
{
    public sealed class StreamConfiguration
    {
        public string Address { get; set; } = "wss://api-invest.tinkoff.ru/openapi/md/v1/md-openapi/ws";

        public string AccessToken { get; set; }
    }
}