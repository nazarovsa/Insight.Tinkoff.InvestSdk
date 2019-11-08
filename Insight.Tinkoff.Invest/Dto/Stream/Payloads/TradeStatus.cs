using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Insight.Tinkoff.Invest.Dto.Payloads
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TradeStatus
    {
        NormalTrading,
        NotAvailableForTrading
    }
}