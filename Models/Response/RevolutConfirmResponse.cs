using Livesoft.Revolut.Models.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livesoft.Revolut.Models.Response
{
    public class RevolutConfirmResponse : RevolutOrderResponse
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("settlement_currency")]
        public string SettlementCurrency { get; set; }

        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }

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
