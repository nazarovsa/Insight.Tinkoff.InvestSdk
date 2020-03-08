using System.Collections.Generic;

namespace Insight.Tinkoff.InvestSdk.Dto.Responses
{
    public sealed class AccountsResponsePayload
    {
        public IReadOnlyCollection<Account> Accounts { get; set; }
    }
}