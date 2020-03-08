using System.Threading;
using System.Threading.Tasks;
using Insight.Tinkoff.InvestSdk.Dto.Responses;

namespace Insight.Tinkoff.InvestSdk.Services
{
    public interface IUserService
    {
        Task<AccountsResponse> GetAccounts(CancellationToken cancellationToken = default);
    }
}