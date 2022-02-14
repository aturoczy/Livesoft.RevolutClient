using Newtonsoft.Json;

namespace Livesoft.Revolut.Models.Response
{
    public class RevolutOrderResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("order_amount")]
        public object OrderAmount { get; set; }

        [JsonProperty("public_id")]
        public string PublicId { get; set; }
    }
}
