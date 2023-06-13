using PayamGostarClient.ApiProvider;
using PayamGostarClient.ApiProvider.Abstractions;

namespace PayamGostarClient.ApiServices.Models
{
    public abstract class BaseApiService
    {
        public PayamGostarClientConfig ClientConfig { get; }

        public IPayamGostarClientAbstractFactory ClientFactory { get; }

        public BaseApiService(PayamGostarClientConfig clientConfig, IPayamGostarClientAbstractFactory clientFactory)
        {
            ClientConfig = clientConfig;

            ClientFactory = clientFactory;
        }
    }
}
