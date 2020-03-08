using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Insight.Tinkoff.InvestSdk.Dto.Responses;
using Insight.Tinkoff.InvestSdk.Infrastructure.Configurations;
using Insight.Tinkoff.InvestSdk.Infrastructure.Services;

namespace Insight.Tinkoff.InvestSdk.Services
{
    public sealed class UserService : IUserService
    {
        private readonly TinkoffRestService _rest;

        public UserService(
            RestConfiguration configuration, HttpClient client = null)
        {
            _rest = new TinkoffRestService(configuration, client);
        }

        public async Task<AccountsResponse> GetAccounts(CancellationToken cancellationToken = default)
        {
            return await _rest.Get<AccountsResponse>("user/accounts", cancellationToken);
        }
    }
}