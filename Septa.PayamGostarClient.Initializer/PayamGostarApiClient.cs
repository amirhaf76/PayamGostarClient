using Septa.PayamGostarClient.Initializer.Core.APIs;
using Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions;
using Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization;
using Septa.PayamGostarClient.Initializer.Models.Customization;
using Septa.PayamGostarClient.Initializer.Models.RestApiConfigBuilder;
using Septa.PayamGostarClient.RestApi.Factory;

namespace Septa.PayamGostarClient.Initializer
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