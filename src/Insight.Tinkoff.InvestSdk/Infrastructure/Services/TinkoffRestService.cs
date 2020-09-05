using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Insight.Tinkoff.InvestSdk.Infrastructure.Configurations;
using Insight.Tinkoff.InvestSdk.Infrastructure.Exceptions;
using Insight.Tinkoff.InvestSdk.Infrastructure.Json;

namespace Insight.Tinkoff.InvestSdk.Infrastructure.Services
{
    internal sealed class TinkoffRestService : RestService
    {
        internal RestConfiguration Configuration { get; }

        internal string SandboxBasePath { get; } = "/openapi/sandbox";

        internal string BasePath { get; } = "/openapi";

        internal TinkoffRestService(RestConfiguration configuration, HttpClient httpClient = null) :
            base(configuration.BaseUrl, httpClient)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            if (string.IsNullOrWhiteSpace(configuration.AccessToken))
                throw new ArgumentNullException(nameof(configuration.AccessToken));

            Configuration = configuration;
        }

        internal Task<T> Get<T>(string path, CancellationToken cancellationToken = default)
            => base.Get<T>(GetPath(path), new AuthenticationHeaderValue("Bearer", Configuration.AccessToken),
                cancellationToken);

        internal Task<TO> Post<TI, TO>(string path, TI payload, CancellationToken cancellationToken = default)
            => base.Post<TI, TO>(GetPath(path), payload,
                new AuthenticationHeaderValue("Bearer", Configuration.AccessToken), cancellationToken);

        protected override async Task<T> GetResponseItem<T>(HttpResponseMessage response)
        {
            var content = await GetResponseContentAsString(response);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                var errorResponse = JSerializer.Deserialize<ErrorResponse>(content);
                if (errorResponse == null)
                    throw new RestServiceException(
                        GetRestServiceExceptionMessage(response.RequestMessage.RequestUri.ToString(),
                            response.StatusCode, content));

                throw new RestServiceException(errorResponse.Payload.Message, errorResponse);
            }

            return JSerializer.Deserialize<T>(content);
        }

        private string GetPath(string path)
        {
            return $"{(Configuration.SandboxMode ? SandboxBasePath : BasePath)}/{path}";
        }
    }
}