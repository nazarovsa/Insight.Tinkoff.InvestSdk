using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Insight.Tinkoff.InvestSdk.Dto
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Currency
    {
        [EnumMember(Value = "RUB")] Rub,
        [EnumMember(Value = "USD")] Usd,
        [EnumMember(Value = "EUR")] Eur,
    }
}