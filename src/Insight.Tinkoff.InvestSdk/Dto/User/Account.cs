using Insight.Tinkoff.InvestSdk.Enums;
using Newtonsoft.Json;

namespace Insight.Tinkoff.InvestSdk.Dto
{
    public sealed class Account
    {
        [JsonConstructor]
        public Account([JsonProperty("brokerAccountType")] BrokerAccountType accountType,
            [JsonProperty("brokerAccountId")] string accountId)
        {
            AccountId = accountId;
            AccountType = accountType;
        }

        public string AccountId { get; set; }
        
        public BrokerAccountType AccountType { get; set; }
    }
}