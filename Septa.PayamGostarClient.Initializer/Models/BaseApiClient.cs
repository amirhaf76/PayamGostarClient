using Septa.PayamGostarClient.Initializer.Core.APIs;
using Septa.PayamGostarClient.RestApi.Factory;

namespace Septa.PayamGostarClient.Initializer.Models
{
    public abstract class BaseApiClient
    {
        protected PayamGostarApiClientConfig ApiClientConfig { get; }

        protected IPayamGostarRestApiClientFactory ApiProviderFactory { get; }

        public BaseApiClient(PayamGostarApiClientConfig apiClientConfig, IPayamGostarRestApiClientFactory apiProviderFactory)
        {
            ApiClientConfig = apiClientConfig;
            ApiProviderFactory = apiProviderFactory;
        }
    }
}
