using Newtonsoft.Json;

namespace Livesoft.RevolutClient.Models.Response
{
    public class RevolutPaymentMethodResponse
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("saved_for")]
        public string SavedFor { get; set; }

        [JsonProperty("method_details")]
        public RevolutMethodDetailsResponse Details { get; set; }
    }
}
