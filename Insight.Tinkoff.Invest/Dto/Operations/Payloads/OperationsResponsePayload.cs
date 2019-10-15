using System.Collections.Generic;

namespace Insight.Tinkoff.Invest.Dto.Operations.Payloads
{
    public sealed class OperationsResponsePayload 
    {
        public IReadOnlyCollection<Operation> Operations { get; set; }
    }
}