using Livesoft.Revolut.Models;
using Livesoft.Revolut.Models.Request;
using Livesoft.Revolut.Models.Response;
using Livesoft.RevolutClient.Models.Response;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Livesoft.RevolutClient.Endpoints
{
    public class Customer : ICustomer
    {
        private const string endpoint = "customers";
        private readonly IHttpClientFactory clientFactory;
        private readonly RevolutConfig config;


        public Customer(IHttpClientFactory clientFactory, RevolutConfig config)
        {
            this.clientFactory = clientFactory; 
            this.config = config;  

        }
        /// <summary>
        /// Create a customer
        /// https://developer.revolut.com/docs/merchant/create-customer
        /// </summary>
        /// <param name="email">The email address of the customer. Uniqueness of customer's email address is not enforced. This means, you can create multiple customer objects with the same email address.</param>
        /// <param name="fullName">The full name of the customer. If full_name is not specified, this value is taken from the cardholder_name the first time a payment is made.</param>
        /// <param name="businessName">The name of the customer's business.</param>
        /// <param name="phone">The phone number of the customer in E.164 format.</param>
        /// <returns></returns>
        public async Task<string> CreateCustomer(string email, string? fullName = null, string? businessName = null, string? phone = null)
        {
            RevolutCustomerPayload customerPayload = new RevolutCustomerPayload()
            {
                BusinessName = businessName,
                Email = email,
                Phone = phone,
                FullName = fullName,
            };

            var requestJson = JsonConvert.SerializeObject(customerPayload, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
            StringContent httpContent = new StringContent(requestJson, Encoding.UTF8, "application/json");
            //httpContent.Headers.Add("Bearer", config.ApiKey);

            using (var httpClient = clientFactory.CreateClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", config.ApiKey);

                var httpResponseMessage = await httpClient.PostAsync(config.Url + endpoint, httpContent);

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
                var httpResponseMessage = await httpClient.DeleteAsync(config.Url + endpoint + "/" + revolutCustomerId);
                httpResponseMessage.EnsureSuccessStatusCode();
            }
        }

        public async Task<RevolutMethodDetailsResponse> RetrivePaymantMethods(Guid revolutCustomerId)
        {
            using (var httpClient = clientFactory.CreateClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", config.ApiKey);
                var httpResponseMessage = await httpClient.GetAsync(config.Url + endpoint + "/" + revolutCustomerId + "/payment-methods");

                var jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                //   httpResponseMessage.EnsureSuccessStatusCode();
                var response = JsonConvert.DeserializeObject<RevolutMethodDetailsResponse>(jsonResponse);
                return response;
            }
        }

        public async Task<string> UpdateCustomer(Guid customerId, string email, string? fullName = null, string? businessName = null, string? phone = null)
        {
            RevolutCustomerPayload customerPayload = new RevolutCustomerPayload()
            {
                FullName = fullName,
                BusinessName = businessName,
                Email = email,
                Phone = phone,
            };

            var requestJson = JsonConvert.SerializeObject(customerPayload, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
            StringContent httpContent = new StringContent(requestJson, Encoding.UTF8, "application/json");
            using (var httpClient = clientFactory.CreateClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", config.ApiKey);
                var httpResponseMessage = await httpClient.PatchAsync(config.Url + endpoint + "/" + customerId.ToString(), httpContent);

                var jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                httpResponseMessage.EnsureSuccessStatusCode();
                var response = JsonConvert.DeserializeObject<RevolutCustomerResponse>(jsonResponse);
                return response.Id;
            }
        }
    }
}
