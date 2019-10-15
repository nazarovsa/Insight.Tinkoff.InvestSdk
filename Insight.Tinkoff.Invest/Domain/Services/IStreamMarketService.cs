using System;
using System.Threading.Tasks;
using Insight.Tinkoff.Invest.Dto.Stream.Messages;

namespace Insight.Tinkoff.Invest.Domain.Services
{
    public interface IStreamMarketService
    {
        Task Send(IWsMessage message);

        IObservable<WsMessage> AsObservable();
    }
}