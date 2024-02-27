using Livesoft.Revolut.Models.Response;

namespace Livesoft.Revolut
{
    public interface IRevolutClient
    {
        Task<RevolutOrderResponse> StartOrderProcess(int amount, string customerId = "");

        Task<RevolutOrderResponse> CancelOrder(string orderId);

        Task<RevolutOrderDetailsResponse[]> GetAllOrders();

        Task<RevolutOrderDetailsResponse> GetOrderDetails(string orderId);

        Task<RevolutOrderResponse> ExecuteOrder(string orderId);

        Task<string> CreateCustomer(string businessName, string fullName, string email, string phone);

        Task DeleteCustomer(int revolutCustomerId);

        Task<string> UpdateCustomer(Guid customerId, string businessName, string fullName, string email, string phone);
    }
}
