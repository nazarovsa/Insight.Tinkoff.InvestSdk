using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Insight.Tinkoff.Invest.Dto.Payloads
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TradeStatus
    {
        [EnumMember(Value = "normal_trading")]
        NormalTrading,
        
        [EnumMember(Value = "not_available_for_trading")]
        NotAvailableForTrading
    }
}