namespace Insight.Tinkoff.Invest.Infrastructure
{
    public sealed class TinkoffRestServiceConfiguration
    {
        public string AccessToken { get; set; }

        public string BaseUrl { get; set; } = "https://api-invest.tinkoff.ru";

        public bool SandboxMode { get; set; } = true;
    }
}