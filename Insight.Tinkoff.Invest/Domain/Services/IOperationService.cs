using System;
using System.Threading;
using System.Threading.Tasks;
using Insight.Tinkoff.Invest.Dto.Operations;
using Insight.Tinkoff.Invest.Dto.Operations.Responses;
using Insight.Tinkoff.Invest.Infrastructure;

namespace Insight.Tinkoff.Invest.Domain.Services
{
    public interface IOperationService
    {
        Task<OperationsResponse> Get(OperationsFilter filter, CancellationToken cancellationToken = default);
    }
}