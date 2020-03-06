using Newtonsoft.Json;

namespace Insight.Tinkoff.InvestSdk.Dto.Payloads
{
    public sealed class ErrorMessagePayload
    {
        [JsonConstructor]
        public ErrorMessagePayload(
            [JsonProperty("request_id")] string requestId,
            string error)
        {
            RequestId = requestId;
            Error = error;
        }

        [JsonProperty] 
        public string RequestId { get; private set; }

        public string Error { get; private set; }
    }
}