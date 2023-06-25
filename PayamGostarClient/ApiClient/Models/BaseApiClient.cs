using PayamGostarClient.ApiProvider;
using PayamGostarClient.ApiProvider.Abstractions;

namespace PayamGostarClient.ApiClient.Models
{
    public abstract class BaseApiClient 
    {
        protected PayamGostarApiClientConfig ApiClientConfig { get; }

        protected IPayamGostarApiProviderFactory ApiProviderFactory { get; }

        public BaseApiClient(PayamGostarApiClientConfig apiClientConfig, IPayamGostarApiProviderFactory apiProviderFactory)
        {
            ApiClientConfig = apiClientConfig;
            ApiProviderFactory = apiProviderFactory;
        }
    }
}
