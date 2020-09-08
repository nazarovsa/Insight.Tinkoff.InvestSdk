using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Insight.Tinkoff.InvestSdk.Infrastructure.Extensions;
using Insight.Tinkoff.InvestSdk.Dto.Responses;
using Insight.Tinkoff.InvestSdk.Infrastructure;
using Insight.Tinkoff.InvestSdk.Infrastructure.Configurations;
using Insight.Tinkoff.InvestSdk.Infrastructure.Services;

namespace Insight.Tinkoff.InvestSdk.Services
{
    public sealed class OperationService : IOperationService
    {
        private readonly TinkoffHttpService _http;

        public OperationService(
            RestConfiguration configuration, HttpClient client = null)
        {
            _http = new TinkoffHttpService(configuration, client);
        }

        public async Task<OperationsResponse> Get(OperationsFilter filter, string brokerAccountId = null,
            CancellationToken cancellationToken = default)
        {
            var query = new Dictionary<string, string>
            {
                {"to", filter.To.ToString("yyyy-MM-ddTHH:mm:ss.ffffffK")},
                {"from", filter.From.ToString("yyyy-MM-ddTHH:mm:ss.ffffffK")},
                {"interval", filter.Interval.GetEnumMemberAttributeValue()}
            };

            if (!string.IsNullOrWhiteSpace(brokerAccountId))
                query.Add("brokerAccountId", brokerAccountId);

            if (!string.IsNullOrEmpty(filter.Figi))
                query.Add("figi", filter.Figi);

            return await _http.Get<OperationsResponse>(
                "operations",
                query,
                cancellationToken: cancellationToken);
        }
    }
}