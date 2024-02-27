using Livesoft.Revolut.Models;
using Livesoft.Revolut.Models.Request;
using Livesoft.Revolut.Models.Response;
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

        public RevolutClient(IOptions<RevolutConfig> options, IHttpClientFactory clientFactory)
        {
            this.config = options.Value;
            this.clientFactory = clientFactory;

        }
        public async Task<string> CreateCustomer(string businessName, string fullName, string email, string phone)
        {
            RevolutCustomerPayload customerPayload = new RevolutCustomerPayload()
            {
                FullName = fullName,
                BusinessName = businessName,
                Email = email,
                Phone = phone,
            };

            var requestJson = JsonConvert.SerializeObject(customerPayload);
            StringContent httpContent = new StringContent(requestJson, Encoding.UTF8, "application/json");
            //httpContent.Headers.Add("Bearer", config.ApiKey);

            using (var httpClient = clientFactory.CreateClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", config.ApiKey);

                var httpResponseMessage = await httpClient.PostAsync(config.Url + "customers", httpContent);

                var jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                //   httpResponseMessage.EnsureSuccessStatusCode();
                var response = JsonConvert.DeserializeObject<RevolutCustomerResponse>(jsonResponse);
                return response.Id;
            }
        }

        public async Task DeleteCustomer(Guid revolutCustomerId)
        {
            using (var httpClient = clientFactory.CreateClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", config.ApiKey);
                var httpResponseMessage = await httpClient.DeleteAsync(config.Url + "customers/" + revolutCustomerId);
                httpResponseMessage.EnsureSuccessStatusCode();
            }
        }

        public async Task<string> UpdateCustomer(Guid customerId, string businessName, string fullName, string email, string phone)
        {
            RevolutCustomerPayload customerPayload = new RevolutCustomerPayload()
            {
                FullName = fullName,
                BusinessName = businessName,
                Email = email,
                Phone = phone,
            };

            var requestJson = JsonConvert.SerializeObject(customerPayload);
            StringContent httpContent = new StringContent(requestJson, Encoding.UTF8, "application/json");
            using (var httpClient = clientFactory.CreateClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", config.ApiKey);
                var httpResponseMessage = await httpClient.PatchAsync(config.Url + "customers/" + customerId.ToString(), httpContent);

                var jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                httpResponseMessage.EnsureSuccessStatusCode();
                var response = JsonConvert.DeserializeObject<RevolutCustomerResponse>(jsonResponse);
                return response.Id;
            }
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
