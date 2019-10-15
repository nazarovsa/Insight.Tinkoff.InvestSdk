using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Insight.Tinkoff.Invest.Dto.Portfolio
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