using System.Runtime.Serialization;

namespace Insight.Tinkoff.Invest.Dto
{
    public enum OperationInterval
    {
        [EnumMember(Value = "1day")]
        Day = 0,

        [EnumMember(Value = "7days")]
        Week = 1,

        [EnumMember(Value = "14days")]
        TwoWeeks = 2,

        [EnumMember(Value = "30days")]
        Month = 3
    }
}