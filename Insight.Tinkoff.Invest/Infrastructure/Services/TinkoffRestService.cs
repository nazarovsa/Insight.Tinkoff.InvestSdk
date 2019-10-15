using System;
using System.Net.Http;

namespace Insight.Tinkoff.Invest.Infrastructure.Services
{
    public abstract class TinkoffRestService : RestService
    {
        protected TinkoffRestServiceConfiguration Configuration { get; }

        protected string SandboxBasePath { get; } = "/openapi/sandbox";
        
        protected string BasePath { get; } = "/openapi";

        protected TinkoffRestService(TinkoffRestServiceConfiguration configuration) : base(
            configuration.BaseUrl)
        {
            if(configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            Configuration = configuration;
        }

        protected override HttpClient CreateClient()
        { 
            var client = new HttpClient { BaseAddress = new Uri(BaseUrl) };
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Configuration.AccessToken}");
            return client;
        }
    }
}