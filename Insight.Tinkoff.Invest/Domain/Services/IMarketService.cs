using System;
using System.Threading;
using System.Threading.Tasks;
using Insight.Tinkoff.Invest.Dto.Payloads;
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
        
        Task<OrderBookResponse> GetOrderBook(string figi, int depth, CancellationToken cancellationToken = default);
        
        Task<CandlesResponse> GetCandles(string figi, DateTime from, DateTime to, CandleInterval interval, CancellationToken cancellationToken = default);
    }
}