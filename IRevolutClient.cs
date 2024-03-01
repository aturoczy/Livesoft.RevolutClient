using Livesoft.RevolutClient.Endpoints;

namespace Livesoft.Revolut
{
    public interface IRevolutClient
    {
        ICustomer Customer { get; }
   
        IOrder Order { get; }
    }
}
