using Livesoft.Revolut.Models;
using Livesoft.RevolutClient.Endpoints;
using Microsoft.Extensions.Options;

namespace Livesoft.Revolut
{
    public class RevolutClient : IRevolutClient
    {
        private readonly RevolutConfig config;
        private readonly ICustomer customer;
        private readonly Order order;
        public ICustomer Customer { get {  return customer; } }
        public IOrder Order { get { return order; } }

        public RevolutClient(IOptions<RevolutConfig> options, IHttpClientFactory clientFactory)
        {
            this.config = options.Value;
            this.customer = new Customer(clientFactory, config);
            this.order = new Order(clientFactory, config);
        }     
    }
}
