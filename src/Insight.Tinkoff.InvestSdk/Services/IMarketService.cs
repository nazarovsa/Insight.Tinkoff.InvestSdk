using System;
using System.Threading;
using System.Threading.Tasks;
using Insight.Tinkoff.InvestSdk.Dto.Payloads;
using Insight.Tinkoff.InvestSdk.Dto.Responses;
using Insight.Tinkoff.InvestSdk.Dto.Stream;

namespace Insight.Tinkoff.InvestSdk.Services
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