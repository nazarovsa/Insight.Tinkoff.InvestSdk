using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Insight.Tinkoff.Invest.Dto.Orders
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OrderType
    {
        Limit,
        Market
    }
}