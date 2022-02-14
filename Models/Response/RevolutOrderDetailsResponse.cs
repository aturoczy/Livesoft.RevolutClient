using Newtonsoft.Json;

namespace Livesoft.Revolut.Models.Response
{
    public class RevolutOrderDetailsResponse : RevolutOrderResponse
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }

        [JsonProperty("settlement_currency")]
        public string SettlementCurrency { get; set; }

        [JsonProperty("merchant_order_ext_ref")]
        public string MerchantOrderExtRef { get; set; }

        [JsonProperty("capture_mode")]
        public string CaptureMode { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }
    }
}
