using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Insight.Tinkoff.InvestSdk.Infrastructure.Extensions;
using Insight.Tinkoff.InvestSdk.Dto.Responses;
using Insight.Tinkoff.InvestSdk.Infrastructure;
using Insight.Tinkoff.InvestSdk.Infrastructure.Configurations;
using Insight.Tinkoff.InvestSdk.Infrastructure.Services;

namespace Insight.Tinkoff.InvestSdk.Services
{
    public sealed class OperationService : IOperationService
    {
        private readonly TinkoffRestService _rest;

        public OperationService(
            RestConfiguration configuration, HttpClient client = null)
        {
            _rest = new TinkoffRestService(configuration, client);
        }

        public async Task<OperationsResponse> Get(OperationsFilter filter, string brokerAccountId = null,
            CancellationToken cancellationToken = default)
        {
            var from = HttpUtility.UrlEncode(filter.From.ToString("yyyy-MM-ddTHH:mm:ss.ffffffK"));
            var to = HttpUtility.UrlEncode(filter.To.ToString("yyyy-MM-ddTHH:mm:ss.ffffffK"));
            var path = $"operations?from={from}&to={to}&interval={filter.Interval.GetEnumMemberAttributeValue()}{BrokerAccountIdQueryHelper.Get(brokerAccountId, "&")}";
            
            if(!string.IsNullOrEmpty(filter.Figi))
                path += $"&figi={filter.Figi}";
                
            return await _rest.Get<OperationsResponse>(
                path,
                cancellationToken);
        }
    }
}
