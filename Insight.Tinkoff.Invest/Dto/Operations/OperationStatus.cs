using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Insight.Tinkoff.Invest.Dto
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OperationStatus
    {
        Done,
        Decline,
        Progress
    }
}