using Livesoft.Revolut.Models.Response;
using Newtonsoft.Json.Linq;

namespace Livesoft.Revolut
{
    public interface IRevolutClient
    {
        Task<RevolutOrderResponse> StartOrderProcess(int amount, string customerId = "");

        Task<RevolutOrderResponse> CancelOrder(string orderId);

        Task<RevolutOrderDetailsResponse[]> GetAllOrders();

        Task<RevolutOrderDetailsResponse> GetOrderDetails(string orderId);

        Task<RevolutOrderResponse> ExecuteOrder(string orderId);

        /// <summary>
        /// Create a customer
        /// https://developer.revolut.com/docs/merchant/create-customer
        /// </summary>
        /// <param name="businessName">The name of the customer's business.</param>
        /// <param name="email">The email address of the customer. Uniqueness of customer's email address is not enforced. This means, you can create multiple customer objects with the same email address.</param>
        /// <param name="phone">The phone number of the customer in E.164 format.</param>
        /// <param name="fullName">The full name of the customer. If full_name is not specified, this value is taken from the cardholder_name the first time a payment is made.</param>
        /// <returns></returns>
        Task<string> CreateCustomer(string businessName, string email, string phone, string fullName = null);

        Task DeleteCustomer(Guid revolutCustomerId);

        Task<string> UpdateCustomer(Guid customerId, string businessName, string fullName, string email, string phone);
    }
}
