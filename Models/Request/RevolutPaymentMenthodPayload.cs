using Newtonsoft.Json;

namespace Livesoft.RevolutClient.Models.Request
{
    public class RevolutPaymentMenthodPayload
    {
        [JsonProperty("customer_id")]
        public required string CustomerId { get; set; }
    }
}
