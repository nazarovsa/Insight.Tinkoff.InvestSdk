namespace Insight.Tinkoff.InvestSdk.Infrastructure.Configurations
{
    public sealed class RestConfiguration
    {
        public string AccessToken { get; set; }

        public string BaseUrl { get; set; } = "https://api-invest.tinkoff.ru";

        public bool SandboxMode { get; set; } = true;
    }
}