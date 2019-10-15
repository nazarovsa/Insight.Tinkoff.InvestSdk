using System.Threading;
using System.Threading.Tasks;
using Insight.Tinkoff.Invest.Dto.Responses;

namespace Insight.Tinkoff.Invest.Domain
{
    public interface IPortfolioService
    {
        Task<CurrenciesResponse> GetCurrencies(CancellationToken token = default);

        Task<PortfolioResponse> GetPortfolio(CancellationToken token = default);
    }
}