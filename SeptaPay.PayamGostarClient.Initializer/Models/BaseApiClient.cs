using SeptaPay.PayamGostarClient.Initializer.Core.APIs;
using SeptaPay.PayamGostarClient.RestApi.Factory;

namespace SeptaPay.PayamGostarClient.Initializer.Models
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
