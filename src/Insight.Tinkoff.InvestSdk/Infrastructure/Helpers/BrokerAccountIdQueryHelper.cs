namespace Insight.Tinkoff.InvestSdk.Infrastructure
{
    internal static class BrokerAccountIdQueryHelper
    {
        internal static string Get(string brokerAccountId, string firstSymbol = "")
        {
            return string.IsNullOrWhiteSpace(brokerAccountId)
                ? string.Empty
                : $"{firstSymbol}brokerAccountId={brokerAccountId}";
        }
    }
}