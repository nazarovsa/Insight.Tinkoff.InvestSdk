using System.Threading;
using System.Threading.Tasks;
using Insight.Tinkoff.InvestSdk.Dto.Responses;

namespace Insight.Tinkoff.InvestSdk.Services
{
    public interface IPortfolioService
    {
        Task<CurrenciesResponse> GetCurrencies(string brokerAccountId = null, CancellationToken cancellationToken = default);

        Task<PortfolioResponse> GetPortfolio(string brokerAccountId = null, CancellationToken cancellationToken = default);
    }
}