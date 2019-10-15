using System;
using System.Threading.Tasks;
using Insight.Tinkoff.Invest.Dto.Messages;

namespace Insight.Tinkoff.Invest.Domain
{
    public interface IStreamMarketService
    {
        Task Send(IWsMessage message);

        IObservable<WsMessage> AsObservable();
    }
}