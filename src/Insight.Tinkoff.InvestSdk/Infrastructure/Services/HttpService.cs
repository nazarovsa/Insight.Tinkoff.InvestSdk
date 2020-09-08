using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Insight.Tinkoff.InvestSdk.Infrastructure.Json;
using Newtonsoft.Json;

namespace Insight.Tinkoff.InvestSdk.Infrastructure.Services
{
    internal abstract class HttpService
    {
        private readonly JsonSerializerSettings _jsonSerializerSetting;

        private readonly string _baseUrl;

        private readonly HttpClient _client;

        protected HttpService(string baseUrl, HttpClient client = null)
        {
            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new ArgumentNullException(nameof(baseUrl));

            _baseUrl = baseUrl;
            _client = client ?? new HttpClient();
        }

        protected HttpService(string baseUrl, JsonSerializerSettings jsonSerializerSetting, HttpClient client = null) :
            this(baseUrl, client)
        {
            _jsonSerializerSetting =
                jsonSerializerSetting ?? throw new ArgumentNullException(nameof(jsonSerializerSetting));
        }

        internal virtual async Task<T> Get<T>(string path, IDictionary<string, string> query = null,
            IDictionary<string, string> customHeaders = null, CancellationToken cancellationToken = default)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, BuildUri(path, query));

            FillRequestHeaders(request, customHeaders);

            using (var response = await _client.SendAsync(request, cancellationToken))
                return await GetResponseItem<T>(response);
        }

        internal virtual async Task<T> Post<T>(string path, object payload, IDictionary<string, string> query = null,
            IDictionary<string, string> customHeaders = null, CancellationToken cancellationToken = default)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, BuildUri(path, query));
            if (payload != null)
            {
                var body = JSerializer.Serialize(payload);
                request.Content = new StringContent(body, Encoding.UTF8, "application/json");
            }

            FillRequestHeaders(request, customHeaders);

            using (var response = await _client.SendAsync(request, cancellationToken))
                return await GetResponseItem<T>(response);
        }

        protected string GetRestServiceExceptionMessage(string uri, HttpStatusCode code, string content)
            => $"Api error. Url: {uri} Code: {(int) code}, Content: {content}";

        protected virtual async Task<T> GetResponseItem<T>(HttpResponseMessage response)
        {
            var content = await GetContentString(response);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new InvalidOperationException(
                    $"Status: {response.StatusCode}, uri: {response.RequestMessage.RequestUri}, content: {content}");

            return JsonConvert.DeserializeObject<T>(content, _jsonSerializerSetting);
        }

        protected async Task<string> GetContentString(HttpResponseMessage response)
            => await response.Content.ReadAsStringAsync();


        private void FillRequestHeaders(HttpRequestMessage request,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders != null && customHeaders.Count != 0)
                foreach (var header in customHeaders)
                    request.Headers.Add(header.Key, header.Value);
        }

        private string BuildUri(string path, IDictionary<string, string> query = null)
        {
            var builder = new UriBuilder($"{_baseUrl.TrimEnd('/')}/{path.TrimStart('/')}");
            if (query == null) return builder.ToString();
            var queryString = HttpUtility.ParseQueryString(builder.Query);
            foreach (var kv in query)
                queryString[kv.Key] = kv.Value;

            builder.Query = queryString.ToString();

            return builder.ToString();
        }
    }
}