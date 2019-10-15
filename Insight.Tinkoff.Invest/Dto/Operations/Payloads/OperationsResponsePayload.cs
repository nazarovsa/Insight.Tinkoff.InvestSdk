using System.Collections.Generic;

namespace Insight.Tinkoff.Invest.Dto.Payloads
{
    public sealed class OperationsResponsePayload 
    {
        public IReadOnlyCollection<Operation> Operations { get; set; }
    }
}