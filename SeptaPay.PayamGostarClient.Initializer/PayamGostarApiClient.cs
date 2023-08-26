using SeptaPay.PayamGostarClient.Initializer.Core.APIs;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Abstractions;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization;
using SeptaPay.PayamGostarClient.Initializer.Models.Customization;
using SeptaPay.PayamGostarClient.Initializer.Models.RestApiConfigBuilder;
using SeptaPay.PayamGostarClient.RestApi.Factory;

namespace SeptaPay.PayamGostarClient.Initializer
{
    public class PayamGostarApiClient : IPayamGostarApiClient
    {
        private readonly PayamGostarApiClientConfig _apiClientConfig;
        private readonly IPayamGostarRestApiClientFactory _apiProviderFactory;

        public PayamGostarApiClient(PayamGostarApiClientConfig config)
        {
            _apiClientConfig = config;

            var apiProviderConfig = new PayamGostarRestApiConfigBuilder(config).Create();

            _apiProviderFactory = new PayamGostarRestApiClientFactory(apiProviderConfig);
        }

        public IPayamGostarCustomizationApiClient CustomizationApi => new PayamGostarCustomizationApiClient(_apiClientConfig, _apiProviderFactory);
    }


}