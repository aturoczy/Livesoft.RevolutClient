
using Livesoft.RevolutClient.Models.Response;

namespace Livesoft.RevolutClient.Endpoints
{
    public interface ICustomer
    {
        /// <summary>
        /// Create a customer
        /// https://developer.revolut.com/docs/merchant/create-customer
        /// </summary>
        /// <param name="email">The email address of the customer. Uniqueness of customer's email address is not enforced. This means, you can create multiple customer objects with the same email address.</param>
        /// <param name="fullName">The full name of the customer. If full_name is not specified, this value is taken from the cardholder_name the first time a payment is made.</param>
        /// <param name="businessName">The name of the customer's business.</param>
        /// <param name="phone">The phone number of the customer in E.164 format.</param>
        /// <returns></returns>
        Task<string> CreateCustomer(string email, string? businessName = null, string? phone = null, string? fullName = null);

        Task DeleteCustomer(Guid revolutCustomerId);

        /// <summary>
        /// Update a customer
        /// https://developer.revolut.com/docs/merchant/update-customer
        /// </summary>
        /// <param name="revolutCustomerId">Revolut Customer Id</param>
        /// <param name="email">The email address of the customer. This value must be unique for each customer for one merchant. If the email address matches an existing customer, an error is returned.</param>
        /// <param name="fullName">The full name of the customer. If full_name is not specified, this value is taken from the cardholder_name the first time a payment is made.</param>
        /// <param name="businessName">The name of the customer's business.</param>
        /// <param name="phone">The phone number of the customer in E.164 format.</param>
        /// <returns>Revolut Customer Id</returns>
        Task<string> UpdateCustomer(Guid revolutCustomerId, string email, string? fullName = null, string? businessName = null, string? phone = null);


        /// <summary>
        /// Retrieve all the payment methods for a specific customer.
        /// </summary>
        /// <param name="revolutCustomerId">Revolut Customer Id</param>
        /// <returns></returns>
        Task<RevolutPaymentMethodResponse[]> RetrivePaymantMethods(Guid revolutCustomerId);

        /// <summary>
        /// Retrieve the information of a specific payment method that is saved.
        /// </summary>
        /// <param name="revolutCustomerId">Revolut Customer Id</param>
        /// <param name="paymentMethodId">The ID of the payment method.</param>
        /// <returns></returns>
        Task<RevolutPaymentMethodResponse> RetrivePaymantMethod(Guid revolutCustomerId, Guid paymentMethodId);

        /// <summary>
        /// Delete a specific payment method. The payment method is completely deleted from the customer payment methods.
        /// To reuse the payment method that is deleted, direct your customer to the checkout page and save the card details again.
        /// </summary>
        /// <param name="revolutCustomerId">The ID of the customer.</param>
        /// <param name="paymentMethodId">The ID of the payment method.</param>
        /// <returns></returns>
        Task DeletePaymentMethod(Guid revolutCustomerId,  Guid paymentMethodId);
    }
}
