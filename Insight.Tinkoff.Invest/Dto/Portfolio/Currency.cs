using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Insight.Tinkoff.Invest.Dto
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Currency
    {
        Rub,

        Usd,

        Eur
    }
}