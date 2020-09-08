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
        private readonly TinkoffHttpService _http;

        public UserService(
            RestConfiguration configuration, HttpClient client = null)
        {
            _http = new TinkoffHttpService(configuration, client);
        }

        public async Task<AccountsResponse> GetAccounts(CancellationToken cancellationToken = default)
        {
            return await _http.Get<AccountsResponse>("user/accounts", cancellationToken: cancellationToken);
        }
    }
}