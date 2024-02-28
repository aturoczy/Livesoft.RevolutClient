using Newtonsoft.Json;

namespace Livesoft.Revolut.Models.Request
{
    public class RevolutOrderPayload 
    {
        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("currency")]
        public required string Currency { get; set; }

        [JsonProperty("customer_id")]
        public required string CustomerId { get; set; }
    }
}
