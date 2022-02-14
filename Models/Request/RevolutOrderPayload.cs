using Newtonsoft.Json;

namespace Livesoft.Revolut.Models.Request
{
    public class RevolutOrderPayload 
    {
        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }
    }
}
