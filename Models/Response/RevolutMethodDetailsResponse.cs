using Newtonsoft.Json;

namespace Livesoft.RevolutClient.Models.Response
{
    public class RevolutMethodDetailsResponse
    {
        [JsonProperty("bin")]
        public string Bin { get; set; }

        [JsonProperty("last4")]
        public string Last4 { get; set; }

        [JsonProperty("expiry_month")]
        public int ExpiryMonth { get; set; }

        [JsonProperty("expiry_year")]
        public int ExpireYear { get; set; }

        [JsonProperty("cardholder_name")]
        public string CardHolderName { get; set; }

        [JsonProperty("brand")]
        public string Brand { get; set; }

        [JsonProperty("funding")]
        public string Funding { get; set; }

        [JsonProperty("issuer")]
        public string Issuer { get; set; }

        [JsonProperty("issuer_country")]
        public string IssuerCountry { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
