using System;
using System.Collections.Generic;
using System.Reactive.Linq;

namespace Insight.Tinkoff.Invest.Infrastructure.Extensions
{
    public static class ObservableExtensions
    {
        private static IEnumerable<IObservable<TSource>> RepeatInfinite<TSource>(IObservable<TSource> source,
            TimeSpan dueTime)
        {
            yield return source;

            while (true)
                yield return source.DelaySubscription(dueTime);
        }

        public static IObservable<TSource> RetryAfterDelay<TSource>(this IObservable<TSource> source, TimeSpan dueTime)
        {
            return RepeatInfinite(source, dueTime).Catch();
        }
    }
}