using Newtonsoft.Json;

namespace Livesoft.RevolutClient.Models.Response
{
    public class RevolutMethodDetailsResponse
    {
        [JsonProperty("bin")]
        ///The BIN of the payment card.
        public string Bin { get; set; }

        [JsonProperty("last4")]
        //The last four digits of the payment card.
        public string Last4 { get; set; }

        [JsonProperty("expiry_month")]
        //The expiry month of the payment card.
        public int ExpiryMonth { get; set; }

        [JsonProperty("expiry_year")]
        //The expiry year of the payment card.
        public int ExpiryYear { get; set; }

        [JsonProperty("billing_address")]
        //The billing address of the payment method.
        public RevolutBillingAddress Billing { get; set; }

        [JsonProperty("cardholder_name")]
        //The name of the cardholder.
        public string CardHolderName { get; set; }

        [JsonProperty("brand")]
        //The brand of the payment card.
        //[VISA, MASTERCARD, MAESTRO]
        public string Brand { get; set; }

        [JsonProperty("funding")]
        //The funding type of the payment card.
        //[DEBIT, CREDIT, PREPAID, DEFERRED_DEBIT, CHARGE]
        public string Funding { get; set; }

        [JsonProperty("issuer")]
        //The issuer of the payment card.
        public string Issuer { get; set; }

        [JsonProperty("issuer_country")]
        //Two-letter country code of the country where the payment card was issued.
        public string IssuerCountry { get; set; }

        [JsonProperty("created_at")]
        //The date and time the payment card was added.
        public DateTime CreatedAt { get; set; }
    }
}
