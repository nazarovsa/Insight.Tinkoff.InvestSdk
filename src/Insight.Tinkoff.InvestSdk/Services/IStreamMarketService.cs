using System;
using System.Threading;
using System.Threading.Tasks;
using Insight.Tinkoff.InvestSdk.Dto.Messages;

namespace Insight.Tinkoff.InvestSdk.Services
{
    public interface IStreamMarketService : IDisposable
    {
        Task Send(IWsMessage message, CancellationToken cancellationToken = default);

        IObservable<IWsMessage> AsObservable();
    }
}