using Newtonsoft.Json;

namespace Insight.Tinkoff.InvestSdk.Dto
{
    public sealed class Account
    {
        [JsonConstructor]
        public Account([JsonProperty("brokerAccountType")] string accountType,
            [JsonProperty("brokerAccountId")] string accountId)
        {
            AccountId = accountId;
            AccountType = accountType;
        }

        public string AccountId { get; set; }
        
        public string AccountType { get; set; }
    }
}