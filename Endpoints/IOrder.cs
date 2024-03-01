using Livesoft.Revolut.Models.Response;

namespace Livesoft.RevolutClient.Endpoints
{
    public interface IOrder
    {
        /// <summary>
        /// Creating orders is one of the basic operations of the Merchant API. Most of the other operations are related to creating orders. 
        /// Furthermore, the payment methods merchants can use to take payments for their orders are also building on order creation.
        /// https://developer.revolut.com/docs/merchant/create-order        /// </summary>
        /// <param name="amount">The amount of the order.</param>
        /// <param name="currency">The currency code in upper case. ISO 4217 </param>
        /// <param name="customerId"></param>
        /// <returns>RevolutOrderResponse</returns>
        Task<RevolutOrderResponse> CreateOrder(int amount, string currency = "EUR", string customerId = "");

        /// <summary>
        /// Cancel an existing uncaptured order.
        /// In the AUTHORISED state, which means that the capture_mode of an order is set to MANUAL and the customer has made a successful payment.
        /// In the PENDING state, which means that it doesn't have any successful payment associated with it.
        /// https://developer.revolut.com/docs/merchant/cancel-order
        /// </summary>
        /// <param name="orderId">The ID of the Order object.</param>
        /// <returns>RevolutOrderResponse</returns>
        Task<RevolutOrderResponse> CancelOrder(string orderId);

        /// <summary>
        /// Retrieve all the orders that you've created. You can also use the query parameters to:
        /// Filter the orders that you want to retrieve, for example, only retrieve the orders that have a specific email. (Filtering)
        /// View the orders without loading all of them at once, for example, return a specified number of orders per page. (Pagination)
        /// </summary>
        /// <returns>RevolutOrderDetailsResponse[]</returns>
        Task<RevolutOrderDetailsResponse[]> GetAllOrders();

        /// <summary>
        /// Retrieve the details of an order that has been created. Provide the unique order ID, and the corresponding order information is returned.
        /// </summary>
        /// <param name="orderId">The ID of the Order object.</param>
        /// <returns>RevolutOrderDetailsResponse</returns>
        Task<RevolutOrderDetailsResponse> RetriveOrderDetails(string orderId);

        /// <summary>
        /// This method is used to capture the funds of an existing, uncaptured order. When the payment for an order is authorised, you can capture the order to send it to the processing stage.
        /// </summary>
        /// <param name="orderId">The ID of the Order object.</param>
        /// <returns>RevolutOrderResponse</returns>
        Task<RevolutOrderResponse> CaptureOrder(string orderId);

        /// <summary>
        /// Issue a refund for a completed order. A refund can be either full or partial. Funds are refunded to the customer's original payment method.
        /// The refund operation creates a new order that represents such refund.
        /// You can initiate a refund for an order only when it is in the COMPLETED state.
        /// https://developer.revolut.com/docs/merchant/refund-order
        /// </summary>
        /// <param name="orderId">The ID of the Order object.</param>
        /// <param name="amount">The amount of the refund .</param>
        /// <param name="description">The amount of the refund .</param>
        /// <param name="merchantOrderExtRef">The amount of the refund .</param>
        /// <param name="metadata">The amount of the refund .</param>
        /// <returns>RevolutOrderResponse</returns>
        Task<RevolutOrderResponse> Refund(Guid orderId, int amount, string? description = null, string? merchantOrderExtRef = null, object? metadata = null);
    }
}
