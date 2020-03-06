namespace Insight.Tinkoff.InvestSdk.Dto
{
    public sealed class SandboxSetCurrencyBalanceRequest
    {
        public Currency Currency { get; set; }

        public decimal Balance { get; set; }
    }
}