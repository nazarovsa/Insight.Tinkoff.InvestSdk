using System;
using System.Threading;
using System.Threading.Tasks;
using Insight.Tinkoff.Invest.Dto.Messages;

namespace Insight.Tinkoff.Invest.Domain
{
    public interface IStreamMarketService : IDisposable
    {
        Task Send(IWsMessage message, CancellationToken cancellationToken = default);

        IObservable<WsMessage> AsObservable();
    }
}