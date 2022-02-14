using Livesoft.Revolut.Models.Request;
using Newtonsoft.Json;

namespace Livesoft.Revolut.Models.Response
{
    public class RevolutCustomerResponse : RevolutCustomerPayload
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
