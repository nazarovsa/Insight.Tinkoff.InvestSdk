using System.Runtime.Serialization;

namespace Insight.Tinkoff.Invest.Dto
{
    public sealed class SandboxSetPositionBalanceRequest
    { 
        public string Figi { get; set; }

        public double? Balance { get; set; }
    }
}
