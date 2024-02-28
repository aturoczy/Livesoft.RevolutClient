using Livesoft.Revolut.Models.Response;
using Livesoft.RevolutClient.Endpoints;
using Newtonsoft.Json.Linq;

namespace Livesoft.Revolut
{
    public interface IRevolutClient
    {
        ICustomer Customer { get; }
        Task<RevolutOrderResponse> StartOrderProcess(int amount, string customerId = "");

        Task<RevolutOrderResponse> CancelOrder(string orderId);

        Task<RevolutOrderDetailsResponse[]> GetAllOrders();

        Task<RevolutOrderDetailsResponse> GetOrderDetails(string orderId);

        Task<RevolutOrderResponse> ExecuteOrder(string orderId);


    }
}
