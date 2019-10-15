using System.Threading;
using System.Threading.Tasks;
using Insight.Tinkoff.Invest.Dto.Portfolio.Responses;

namespace Insight.Tinkoff.Invest.Domain.Services
{
    public interface IPortfolioService
    {
        Task<CurrenciesResponse> GetCurrencies(CancellationToken token = default);

        Task<PortfolioResponse> GetPortfolio(CancellationToken token = default);
    }
}