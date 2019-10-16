using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Insight.Tinkoff.Invest.Infrastructure.Exceptions;
using Insight.Tinkoff.Invest.Infrastructure.Json;
using MimeMapping;
using Newtonsoft.Json;

namespace Insight.Tinkoff.Invest.Infrastructure.Services
{
    public abstract class RestService
    {
        private HttpClient _client;

        protected string BaseUrl { get; }

        protected RestService(string baseUrl)
        {
            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new ArgumentNullException(nameof(baseUrl));

            BaseUrl = baseUrl;
        }

        protected async Task<T> Post<T>(string path, string payload, CancellationToken cancellationToken = default)
        {
            var content = new StringContent(payload ?? string.Empty, Encoding.UTF8, KnownMimeTypes.Json);
            var url = GetRequestUrl(path);
            var client = EnsureHttpClientCreated();
            var response = await client.PostAsync(url, content, cancellationToken);
            return await GetResponseItem<T>(path, response);
        }

        protected async Task<T> Get<T>(string path, CancellationToken cancellationToken = default)
        {
            var url = GetRequestUrl(path);
            var client = EnsureHttpClientCreated();
            var response = await client.GetAsync(url, cancellationToken);
            return await GetResponseItem<T>(path, response);
        }

        protected async Task<T> Delete<T>(string path, CancellationToken cancellationToken = default)
        {
            var url = GetRequestUrl(path);
            var client = EnsureHttpClientCreated();
            var response = await client.DeleteAsync(url, cancellationToken);
            return await GetResponseItem<T>(path, response);
        }

        protected async Task<T> Put<T>(string path, string payload, CancellationToken cancellationToken = default)
        {
            var content = new StringContent(payload ?? string.Empty, Encoding.UTF8, KnownMimeTypes.Json);
            var url = GetRequestUrl(path);
            var client = EnsureHttpClientCreated();
            var response = await client.PutAsync(url, content, cancellationToken);
            return await GetResponseItem<T>(path, response);
        }

        protected virtual async Task<T> GetResponseItem<T>(string path, HttpResponseMessage response)
        {
            var json = await GetResponseString(response);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new RestServiceException(GetRestServiceExceptionMessage(path, response.StatusCode));
            
            return JSerializer.Deserialize<T>(json);
        }

        protected Uri GetRequestUrl(string path)
        {
            return new UriBuilder($"{BaseUrl}{path}").Uri;
        }

        protected async Task<string> GetResponseString(HttpResponseMessage response)
            => Encoding.UTF8.GetString(await response.Content.ReadAsByteArrayAsync());

        protected string GetRestServiceExceptionMessage(string path, HttpStatusCode code)
            => $"Ошибка в результате запроса к апи. Url: {path} Код: {(int) code}";

        private HttpClient EnsureHttpClientCreated()
        {
            if (_client == null)
                _client = CreateClient();

            return _client;
        }

        protected virtual HttpClient CreateClient()
        {
            return new HttpClient {BaseAddress = new Uri(BaseUrl)};
        }
    }
}