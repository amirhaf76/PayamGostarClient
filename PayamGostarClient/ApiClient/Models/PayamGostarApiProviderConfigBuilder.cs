using PayamGostarClient.ApiClient.Abstractions;
using PayamGostarClient.ApiProvider;
using PayamGostarClient.Helper.Net;

namespace PayamGostarClient.ApiClient.Models
{
    public class PayamGostarApiProviderConfigBuilder : IPayamGostarApiProviderConfigBuilder
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
                    // DeviceId
                    // ClientId
                },
            };
        }
    }

}