using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Insight.Tinkoff.InvestSdk.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BrokerAccountType
    {
        Tinkoff = 1,
        TinkoffIis = 2
    }
}