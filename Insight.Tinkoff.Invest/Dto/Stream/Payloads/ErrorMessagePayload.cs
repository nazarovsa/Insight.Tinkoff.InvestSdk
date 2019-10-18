using Newtonsoft.Json;

namespace Insight.Tinkoff.Invest.Dto.Payloads
{
    public sealed class ErrorMessagePayload
    {
        [JsonProperty("request_id")]
        public string RequestId { get; set; }
        
        public string Error { get; set; }
    }
}