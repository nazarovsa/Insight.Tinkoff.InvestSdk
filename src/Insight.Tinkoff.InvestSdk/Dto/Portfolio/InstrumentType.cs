using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Insight.Tinkoff.InvestSdk.Dto
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum InstrumentType
    {
        Stock,
        Currency,
        Bond,
        Etf
    }
}