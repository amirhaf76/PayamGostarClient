using PayamGostarClient.ApiClient.Abstractions.ApiProviderConfigBuilder;
using PayamGostarClient.ApiClient.ApiProvider;
using PayamGostarClient.Helper.Net;

namespace PayamGostarClient.ApiClient.Models.ApiProviderConfigBuilder
{
    internal class PayamGostarApiProviderConfigBuilder : IPayamGostarApiProviderConfigBuilder
    {
        private readonly PayamGostarApiClientConfig _config;

        public PayamGostarApiProviderConfigBuilder(PayamGostarApiClientConfig config)
        {
            _config = config;
        }

        public PayamGostarApiProviderConfig Create()
        {
            return new PayamGostarApiProviderConfig
            {
                LanguageCulture = _config.LanguageCulture,
                ClientApiIntraction = new ClientApiIntraction
                {
                    DomainUrl = _config.Url,
                    JwtToken = _config.JwToken,
                    BasicParam = _config.BasicParam,
                    // DeviceId
                    // ClientId
                },
            };
        }
    }

}