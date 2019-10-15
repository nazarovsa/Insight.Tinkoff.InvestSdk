using System.Threading;
using System.Threading.Tasks;
using Insight.Tinkoff.Invest.Dto.Responses;

namespace Insight.Tinkoff.Invest.Domain
{
    public interface IMarketService
    {
        Task<MarketInstrumentListResponse> GetBonds(CancellationToken cancellationToken = default);
        
        Task<MarketInstrumentListResponse> GetCurrencies(CancellationToken cancellationToken = default);
        
        Task<MarketInstrumentListResponse> GetEtfs(CancellationToken cancellationToken = default);
        
        Task<MarketInstrumentListResponse> GetStocks(CancellationToken cancellationToken = default);
        
        Task<MarketInstrumentSearchResponse> SearchByFigi(string figi, CancellationToken cancellationToken = default);
        
        Task<MarketInstrumentListResponse> SearchByTicker(string ticker, CancellationToken cancellationToken = default);
        
    }
}