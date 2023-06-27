using PayamGostarClient.ApiProvider.Abstractions;
using PayamGostarClient.ApiProvider.Factory;
using PayamGostarClient.ApiClient.Abstractions;
using PayamGostarClient.ApiClient.Models;

namespace PayamGostarClient.ApiClient
{
    public class PayamGostarApiClient : IPayamGostarApiClient
    {
        private readonly PayamGostarApiClientConfig _apiClientConfig;
        private readonly IPayamGostarApiProviderFactory _apiProviderFactory;

        public PayamGostarApiClient(PayamGostarApiClientConfig config)
        {
            _apiClientConfig = config;

            var apiProviderConfig = new PayamGostarApiProviderConfigBuilder(config).Create();

            _apiProviderFactory = new PayamGostarApiProviderFactory(apiProviderConfig);
        }

        public IPayamGostarCustomizationApiClient CustomizationApi => new PayamGostarCustomizationApiClient(_apiClientConfig, _apiProviderFactory);
    }


}