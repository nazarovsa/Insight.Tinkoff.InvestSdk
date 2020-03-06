using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Insight.Tinkoff.InvestSdk.Dto
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OrderStatus
    {
        New,
        PartiallyFill,
        Fill,
        Cancelled,
        Replaced,
        PendingCancel,
        Rejected,
        PendingReplace,
        PendingNew
    }
}