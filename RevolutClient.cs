using Livesoft.Revolut.Models;
using Livesoft.Revolut.Models.Request;
using Livesoft.Revolut.Models.Response;
using Livesoft.RevolutClient.Endpoints;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Livesoft.Revolut
{
    public class RevolutClient : IRevolutClient
    {
        private readonly RevolutConfig config;
        private readonly IHttpClientFactory clientFactory;
        private readonly ICustomer customer;
        public ICustomer Customer { get {  return customer; } }

        public RevolutClient(IOptions<RevolutConfig> options, IHttpClientFactory clientFactory)
        {
            this.config = options.Value;
            this.clientFactory = clientFactory;
            this.customer = new Customer(clientFactory, config);
        }

        public async Task<RevolutOrderResponse> StartOrderProcess(int amount, string customerId)
        {
            RevolutOrderPayload payload = new RevolutOrderPayload()
            {
                Amount = amount,
                Currency = config.Currency,
                CustomerId = customerId
            };

            var requestJson = JsonConvert.SerializeObject(payload);
            StringContent httpContent = new StringContent(requestJson, Encoding.UTF8, "application/json");
            using (var httpClient = clientFactory.CreateClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", config.ApiKey);
                var httpResponseMessage = await httpClient.PostAsync(config.Url + "orders", httpContent);
                httpResponseMessage.EnsureSuccessStatusCode();
                var jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<RevolutOrderResponse>(jsonResponse);
                return response;
            }
        }

        public async Task<RevolutOrderResponse> ExecuteOrder(string orderId)
        {
            using (var httpClient = clientFactory.CreateClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", config.ApiKey);
                var httpResponseMessage = await httpClient.PostAsync(config.Url + "orders/" + orderId + "/confirm", null);
                httpResponseMessage.EnsureSuccessStatusCode();
                var jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<RevolutOrderResponse>(jsonResponse);
                return response;
            }
        }

        public async Task<RevolutOrderDetailsResponse> GetOrderDetails(string orderId)
        {
            using (var httpClient = clientFactory.CreateClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", config.ApiKey);
                var httpResponseMessage = await httpClient.GetAsync(config.Url + "orders/" + orderId);
                httpResponseMessage.EnsureSuccessStatusCode();
                var jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<RevolutOrderDetailsResponse>(jsonResponse);
                return response;
            }
        }

        public async Task<RevolutOrderResponse> CancelOrder(string orderId)
        {
            using (var httpClient = clientFactory.CreateClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", config.ApiKey);
                var httpResponseMessage = await httpClient.PostAsync(config.Url + "orders/" + orderId + "/cancel", null);
                httpResponseMessage.EnsureSuccessStatusCode();
                var jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<RevolutOrderResponse>(jsonResponse);
                return response;
            }
        }

        public async Task<RevolutOrderDetailsResponse[]> GetAllOrders()
        {
            using (var httpClient = clientFactory.CreateClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", config.ApiKey);
                var httpResponseMessage = await httpClient.GetAsync(config.Url + "orders/");
                httpResponseMessage.EnsureSuccessStatusCode();
                var jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<RevolutOrderDetailsResponse[]>(jsonResponse);
                return response;
            }
        }


    }
}
