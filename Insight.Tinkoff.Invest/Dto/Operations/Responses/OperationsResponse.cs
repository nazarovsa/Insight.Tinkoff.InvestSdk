using System.Collections.Generic;
using Insight.Tinkoff.Invest.Dto.Operations.Payloads;
using Insight.Tinkoff.Invest.Infrastructure;
using Newtonsoft.Json;

namespace Insight.Tinkoff.Invest.Dto.Operations.Responses
{
    public sealed class OperationsResponse : ResponseBase
    {
        public IReadOnlyCollection<Operation> Operations { get; }

        [JsonConstructor]
        public OperationsResponse([JsonProperty("payload")] OperationsResponsePayload payload)
        {
            Operations = payload.Operations;
        }
    }
}