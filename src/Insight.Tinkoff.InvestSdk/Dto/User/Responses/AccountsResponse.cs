using System.Collections.Generic;
using Insight.Tinkoff.InvestSdk.Infrastructure;
using Newtonsoft.Json;

namespace Insight.Tinkoff.InvestSdk.Dto.Responses
{
    public sealed class AccountsResponse : ResponseBase
    {
        [JsonProperty]
        public IReadOnlyCollection<Account> Accounts { get; }

        [JsonConstructor]
        public AccountsResponse(AccountsResponsePayload payload)
        {
            Accounts = payload.Accounts;
        }
    }
}