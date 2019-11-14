using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Insight.Tinkoff.Invest.Domain;
using Insight.Tinkoff.Invest.Dto.Responses;
using Insight.Tinkoff.Invest.Infrastructure;
using Insight.Tinkoff.Invest.Infrastructure.Configurations;
using Insight.Tinkoff.Invest.Infrastructure.Extensions;
using Insight.Tinkoff.Invest.Infrastructure.Services;

namespace Insight.Tinkoff.Invest.Services
{
    public sealed class OperationService : IOperationService
    {
        private readonly TinkoffRestService _rest;

        public OperationService(
            RestConfiguration configuration)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            _rest = new TinkoffRestService(configuration);
        }

        public async Task<OperationsResponse> Get(OperationsFilter filter,
            CancellationToken cancellationToken = default)
        {
            var from = HttpUtility.UrlEncode(filter.From.ToString("yyyy-MM-ddTHH:mm:ss.ffffffK"));
            var to = HttpUtility.UrlEncode(filter.To.ToString("yyyy-MM-ddTHH:mm:ss.ffffffK"));
            return await _rest.Get<OperationsResponse>(
                $"operations?from={from}&to={to}&interval={filter.Interval.GetEnumMemberAttributeValue()}&figi={filter.Figi}",
                cancellationToken);
        }
    }
}