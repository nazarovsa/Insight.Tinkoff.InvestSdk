using Insight.Tinkoff.Invest.Dto.Portfolio;

namespace Insight.Tinkoff.Invest.Dto.Sandbox
{
    public sealed class SandboxSetCurrencyBalanceRequest
    {
        public Currency Currency { get; set; }

        public decimal Balance { get; set; }
    }
}