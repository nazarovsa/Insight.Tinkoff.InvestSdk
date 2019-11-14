using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Insight.Tinkoff.Invest.Infrastructure.Configurations;
using Insight.Tinkoff.Invest.Infrastructure.Exceptions;
using Insight.Tinkoff.Invest.Infrastructure.Json;

namespace Insight.Tinkoff.Invest.Infrastructure.Services
{
    internal sealed class TinkoffRestService : RestService
    {
        internal RestConfiguration Configuration { get; }

        internal string SandboxBasePath { get; } = "/openapi/sandbox";

        internal string BasePath { get; } = "/openapi";

        internal TinkoffRestService(RestConfiguration configuration) :
            base(configuration.BaseUrl)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            Configuration = configuration;
        }

        internal override Task<T> Get<T>(string path, CancellationToken cancellationToken = default)
            => base.Get<T>(GetPath(path), cancellationToken);

        internal override Task<TO> Post<TI, TO>(string path, TI payload, CancellationToken cancellationToken = default)
            => base.Post<TI, TO>(GetPath(path), payload, cancellationToken);

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

        private string GetPath(string path)
        {
            return $"{(Configuration.SandboxMode ? SandboxBasePath : BasePath)}/{path}";
        }

        protected override HttpClient CreateClient()
        {
            var client = new HttpClient {BaseAddress = new Uri(BaseUrl)};
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", Configuration.AccessToken);
            return client;
        }
    }
}