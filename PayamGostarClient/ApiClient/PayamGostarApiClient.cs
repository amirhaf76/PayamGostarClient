using PayamGostarClient.ApiClient.Abstractions;
using PayamGostarClient.ApiClient.Abstractions.Customization;
using PayamGostarClient.ApiClient.ApiProvider.Abstractions;
using PayamGostarClient.ApiClient.ApiProvider.Factory;
using PayamGostarClient.ApiClient.Models.ApiProviderConfigBuilder;
using PayamGostarClient.ApiClient.Models.Customization;

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