using Newtonsoft.Json;

namespace Livesoft.RevolutClient.Models.Request
{
    public class RevolutRefundRequest
    {
        [JsonProperty("amount")]
        //The amount of the refund (minor currency unit). For example, enter 7034 for €70.34 in the field.
        //This amount can't exceed the remaining amount of the original order. To get the refundable amount, subtract the value of the refunded_amount from the value of the order_amount in the original order.
        public required int Amount { get; set; }

        [JsonProperty("description")]
        //The description of the refund.
        public string? Description { get; set; }

        [JsonProperty("merchant_order_ext_ref")]
        //Merchant order ID for external reference.
        //Use this field to set the ID that your own system can use to easily track orders.
        public string? MerchantOrderExtRef { get; set; }

        [JsonProperty("metadata")]
        //Additional information to track your orders in your system, by providing custom metadata.
        //Max length of metadata values: 500
        //Format of metadata keys: ^[a-zA-Z][a-zA-Z\\d_]{0,39}$
        public object? MetaData { get; set; }
    }
}
