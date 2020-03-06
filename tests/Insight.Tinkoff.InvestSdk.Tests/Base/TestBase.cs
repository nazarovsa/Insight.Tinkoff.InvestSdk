using System;
using System.IO;
using Insight.Tinkoff.InvestSdk.Infrastructure;
using Insight.Tinkoff.InvestSdk.Infrastructure.Configurations;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Insight.Tinkoff.InvestSdk.Tests.Base
{
    public class TestBase
    {
        public TestBase()
        {
            Token = TestConfigurationManager.GetToken();
            RestConfiguration = new RestConfiguration
            {
                AccessToken = Token
            };
        }

        protected string Token { get; }

        protected RestConfiguration RestConfiguration { get; }

        protected void ValidateRestResponse(ResponseBase response)
        {
            Assert.NotNull(response);
            Assert.Equal("ok", response.Status, true);
        }
        
        private static class TestConfigurationManager
        {
            private static readonly Lazy<JObject> _config =
                new Lazy<JObject>(() => JObject.Parse(File.ReadAllText("appsettings.json")), true);

            public static string GetToken()
            {
                return _config.Value["AccessToken"]?.ToString();
            }
        }
    }
}