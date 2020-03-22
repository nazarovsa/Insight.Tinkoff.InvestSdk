using System;

namespace Insight.Tinkoff.InvestSdk.Infrastructure.Configurations
{
    public sealed class StreamConfiguration
    {
        public string Address { get; set; } = "wss://api-invest.tinkoff.ru/openapi/md/v1/md-openapi/ws";

        public string AccessToken { get; set; }

        public bool ResubscribeOnReconnect { get; set; } = true;
        
        public bool ReconnectEnabled { get; set; } = true;
        
        public TimeSpan ReconnectTimeout { get; set; } = TimeSpan.FromSeconds(30);

        public TimeSpan ErrorReconnectTimeout { get; set; } = TimeSpan.FromSeconds(60);
    }
}