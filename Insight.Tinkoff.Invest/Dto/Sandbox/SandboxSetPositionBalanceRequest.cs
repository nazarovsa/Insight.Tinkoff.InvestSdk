using System.Runtime.Serialization;

namespace Insight.Tinkoff.Invest.Dto
{
    public sealed class SandboxSetPositionBalanceRequest
    { 
        [DataMember(Name="figi")]
        public string Figi { get; set; }

        [DataMember(Name="balance")]
        public double? Balance { get; set; }
    }
}
