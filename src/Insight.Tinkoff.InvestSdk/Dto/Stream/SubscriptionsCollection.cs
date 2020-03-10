using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Insight.Tinkoff.InvestSdk.Dto.Stream
{
    public sealed class SubscriptionsCollection
    {
        private readonly HashSet<IWsMessage> _subscriptions;

        private readonly ReaderWriterLockSlim _lock;

        public HashSet<IWsMessage> Subscriptions
        {
            get
            {
                try
                {
                    _lock.EnterReadLock();
                    return _subscriptions;
                }
                finally
                {
                    _lock.ExitReadLock();
                }
            }
        }

        public SubscriptionsCollection()
        {
            _lock = new ReaderWriterLockSlim();
            _subscriptions = new HashSet<IWsMessage>();
        }

        public void Push(IWsMessage message)
        {
            try
            {
                _lock.EnterWriteLock();

                if (message.Event.EndsWith(":subscribe"))
                {
                    if (!_subscriptions.Contains(message))
                        _subscriptions.Add(message);
                }
                else if (message.Event.EndsWith(":unsubscribe"))
                {
                    switch (message.Event)
                    {
                        case EventType.UnsubscribeCandle:
                            if (message is UnsubscribeCandleMessage cm)
                            {
                                var founded = _subscriptions
                                    .OfType<SubscribeCandleMessage>()
                                    .SingleOrDefault(x => x.Figi == cm.Figi
                                                          && x.Interval == cm.Interval);
                                if (founded != null)
                                    _subscriptions.Remove(founded);
                            }

                            break;
                        case EventType.UnsubscribeInstrumentInfo:
                            if (message is UnsubscribeInstrumentInfoMessage iim)
                            {
                                var founded = _subscriptions
                                    .OfType<SubscribeInstrumentInfoMessage>()
                                    .SingleOrDefault(x => x.Figi == iim.Figi);

                                if (founded != null)
                                    _subscriptions.Remove(founded);
                            }

                            break;
                        case EventType.UnsubscribeOrderBook:
                            if (message is UnsubscribeOrderBookMessage obm)
                            {
                                var founded = _subscriptions
                                    .OfType<SubscribeOrderBookMessage>()
                                    .SingleOrDefault(x =>
                                        x.Figi == obm.Figi
                                        && x.Depth == obm.Depth);

                                if (founded != null)
                                    _subscriptions.Remove(founded);
                            }

                            break;
                    }
                }
                else
                {
                    throw new ArgumentException(nameof(message.Event));
                }
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }
    }
}