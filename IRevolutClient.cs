﻿using Livesoft.Revolut.Models.Response;
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
        /// <param name="email">The email address of the customer. Uniqueness of customer's email address is not enforced. This means, you can create multiple customer objects with the same email address.</param>
        /// <param name="fullName">The full name of the customer. If full_name is not specified, this value is taken from the cardholder_name the first time a payment is made.</param>
        /// <param name="businessName">The name of the customer's business.</param>
        /// <param name="phone">The phone number of the customer in E.164 format.</param>
        /// <returns></returns>
        Task<string> CreateCustomer(string businessName, string email, string phone, string fullName = null);

        Task DeleteCustomer(Guid revolutCustomerId);

        /// <summary>
        /// Update a customer
        /// https://developer.revolut.com/docs/merchant/update-customer
        /// </summary>
        /// <param name="customerId">Revolut Customer Id</param>
        /// <param name="email">The email address of the customer. This value must be unique for each customer for one merchant. If the email address matches an existing customer, an error is returned.</param>
        /// <param name="fullName">The full name of the customer. If full_name is not specified, this value is taken from the cardholder_name the first time a payment is made.</param>
        /// <param name="businessName">The name of the customer's business.</param>
        /// <param name="phone">The phone number of the customer in E.164 format.</param>
        /// <returns>Revolut Customer Id</returns>
        Task<string> UpdateCustomer(Guid customerId, string email, string? fullName = null, string? businessName = null, string? phone = null);
    }
}
