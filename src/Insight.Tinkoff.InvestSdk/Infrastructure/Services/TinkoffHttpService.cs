using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Insight.Tinkoff.InvestSdk.Infrastructure.Configurations;
using Insight.Tinkoff.InvestSdk.Infrastructure.Exceptions;
using Insight.Tinkoff.InvestSdk.Infrastructure.Json;

namespace Insight.Tinkoff.InvestSdk.Infrastructure.Services
{
    internal sealed class TinkoffHttpService : HttpService
    {
        internal RestConfiguration Configuration { get; }

        internal string SandboxBasePath { get; } = "/openapi/sandbox";

        internal string BasePath { get; } = "/openapi";

        internal TinkoffHttpService(RestConfiguration configuration, HttpClient httpClient = null)
            : base(configuration.BaseUrl, httpClient)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            if (string.IsNullOrWhiteSpace(configuration.AccessToken))
                throw new ArgumentNullException(nameof(configuration.AccessToken));

            Configuration = configuration;
        }

        internal override Task<T> Get<T>(string path,
            IDictionary<string, string> query = null,
            IDictionary<string, string> customHeaders = null,
            CancellationToken cancellationToken = default)
        {
            if (customHeaders == null)
                customHeaders = new Dictionary<string, string>();

            customHeaders.Add("Authorization", $"Bearer {Configuration.AccessToken}");

            return base.Get<T>(GetPath(path), query,
                customHeaders,
                cancellationToken);
        }

        internal override Task<T> Post<T>(string path, object payload,
            IDictionary<string, string> query = null,
            IDictionary<string, string> customHeaders = null,
            CancellationToken cancellationToken = default)
        {
            if (customHeaders == null)
                customHeaders = new Dictionary<string, string>();

            customHeaders.Add("Authorization", $"Bearer {Configuration.AccessToken}");

            return base.Post<T>(GetPath(path), payload, query, customHeaders, cancellationToken);
        }


        protected override async Task<T> GetResponseItem<T>(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();
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