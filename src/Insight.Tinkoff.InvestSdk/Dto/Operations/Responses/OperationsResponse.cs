using System.Collections.Generic;
using Insight.Tinkoff.InvestSdk.Dto.Payloads;
using Insight.Tinkoff.InvestSdk.Infrastructure;
using Newtonsoft.Json;

namespace Insight.Tinkoff.InvestSdk.Dto.Responses
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