using System.Threading;
using System.Threading.Tasks;
using Insight.Tinkoff.InvestSdk.Dto.Responses;

namespace Insight.Tinkoff.InvestSdk.Services
{
    public interface IPortfolioService
    {
        Task<CurrenciesResponse> GetCurrencies(CancellationToken token = default);

        Task<PortfolioResponse> GetPortfolio(CancellationToken token = default);
    }
}