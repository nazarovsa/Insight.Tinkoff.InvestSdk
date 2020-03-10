using System;
using System.Threading;
using System.Threading.Tasks;
using Insight.Tinkoff.InvestSdk.Dto.Stream;

namespace Insight.Tinkoff.InvestSdk.Services
{
    public interface IStreamMarketService
    {
        Task Send(IWsMessage message, CancellationToken cancellationToken = default);

        IObservable<IWsMessage> AsObservable();
    }
}