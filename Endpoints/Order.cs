using Livesoft.Revolut.Models;
using Livesoft.Revolut.Models.Request;
using Livesoft.Revolut.Models.Response;
using Livesoft.RevolutClient.Models.Request;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Livesoft.RevolutClient.Endpoints
{
    public class Order : IOrder
    {
        private const string endpoint = "orders";
        private readonly IHttpClientFactory clientFactory;
        private readonly RevolutConfig config;

        public Order(IHttpClientFactory clientFactory, RevolutConfig config)
        {
            this.clientFactory = clientFactory;
            this.config = config;
        }

        public async Task<RevolutOrderResponse> CreateOrder(int amount, string currency = "EUR", string customerId = "")
        {
            RevolutOrderPayload payload = new RevolutOrderPayload()
            {
                Amount = amount,
                Currency = currency,
                CustomerId = customerId
            };

            var requestJson = JsonConvert.SerializeObject(payload);
            StringContent httpContent = new StringContent(requestJson, Encoding.UTF8, "application/json");
            using (var httpClient = clientFactory.CreateClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", config.ApiKey);
                var httpResponseMessage = await httpClient.PostAsync(config.Url + endpoint, httpContent);
                httpResponseMessage.EnsureSuccessStatusCode();
                var jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<RevolutOrderResponse>(jsonResponse);
                return response;
            }
        }

        public async Task<RevolutOrderResponse> CaptureOrder(string orderId)
        {
            using (var httpClient = clientFactory.CreateClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", config.ApiKey);
                var httpResponseMessage = await httpClient.PostAsync(config.Url + endpoint + "/" + orderId + "/confirm", null);
                httpResponseMessage.EnsureSuccessStatusCode();
                var jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<RevolutOrderResponse>(jsonResponse);
                return response;
            }
        }

        public async Task<RevolutOrderDetailsResponse> RetriveOrderDetails(string orderId)
        {
            using (var httpClient = clientFactory.CreateClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", config.ApiKey);
                var httpResponseMessage = await httpClient.GetAsync(config.Url + endpoint + "/" + orderId);
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
                var httpResponseMessage = await httpClient.PostAsync(config.Url + endpoint + "/" + orderId + "/cancel", null);
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
                var httpResponseMessage = await httpClient.GetAsync(config.Url + endpoint);
                httpResponseMessage.EnsureSuccessStatusCode();
                var jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<RevolutOrderDetailsResponse[]>(jsonResponse);
                return response;
            }
        }

        public async Task<RevolutOrderResponse> Refund(Guid orderId, int amount, string? description = null, string? merchantOrderExtRef = null, object? metadata = null)
        {
            RevolutRefundRequest payload = new RevolutRefundRequest()
            {
                Amount = amount,
                Description = description,
                MerchantOrderExtRef = merchantOrderExtRef,
                MetaData = metadata,
            };

            var requestJson = JsonConvert.SerializeObject(payload, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
            StringContent httpContent = new StringContent(requestJson, Encoding.UTF8, "application/json");
            using (var httpClient = clientFactory.CreateClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", config.ApiKey);
                var httpResponseMessage = await httpClient.PostAsync(config.Url + endpoint + "/" + orderId + "/refund", httpContent);
                httpResponseMessage.EnsureSuccessStatusCode();
                var jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<RevolutOrderResponse>(jsonResponse);
                return response;
            }
        }
    }
}
