using System.Threading;
using System.Threading.Tasks;
using Insight.Tinkoff.Invest.Domain;
using Insight.Tinkoff.Invest.Dto.Responses;
using Insight.Tinkoff.Invest.Infrastructure;
using Insight.Tinkoff.Invest.Infrastructure.Services;

namespace Insight.Tinkoff.Invest.Services
{
    public sealed class OperationService : TinkoffRestService, IOperationService
    {
        public OperationService(
            TinkoffRestServiceConfiguration configuration) :
            base(configuration)
        {
        }

        public async Task<OperationsResponse> Get(OperationsFilter filter,
            CancellationToken cancellationToken = default)
        {
            return await Get<OperationsResponse>(
                $"{(Configuration.SandboxMode ? SandboxBasePath : BasePath)}/operations?from={filter.From:yyyy-MM-dd}&interval={filter.Interval.ToParamString()}&figi={filter.Figi}",
                cancellationToken);
        }
    }
}