using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Insight.Tinkoff.Invest.Infrastructure.Configurations;
using Insight.Tinkoff.Invest.Infrastructure.Exceptions;
using Insight.Tinkoff.Invest.Infrastructure.Json;

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

        protected override async Task<T> GetResponseItem<T>(string path, HttpResponseMessage response)
        {
            var json = await GetResponseString(response);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                var errorResponse = JSerializer.Deserialize<ErrorResponse>(json);
                if (errorResponse == null)
                    throw new RestServiceException(GetRestServiceExceptionMessage(path, response.StatusCode));
                
                throw new RestServiceException(errorResponse.Payload.Message, errorResponse);
            }

            return JSerializer.Deserialize<T>(json);
        }

        protected override HttpClient CreateClient()
        { 
            var client = new HttpClient { BaseAddress = new Uri(BaseUrl) };
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",  Configuration.AccessToken);
            return client;
        }
    }
}