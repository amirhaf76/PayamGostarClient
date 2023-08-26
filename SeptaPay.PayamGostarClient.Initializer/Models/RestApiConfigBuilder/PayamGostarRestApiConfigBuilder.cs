using SeptaPay.PayamGostarClient.Initializer.Core.APIs;
using SeptaPay.PayamGostarClient.RestApi;
using SeptaPay.PayamGostarClient.RestApi.ClientInteractions;

namespace SeptaPay.PayamGostarClient.Initializer.Models.RestApiConfigBuilder
{
    internal class PayamGostarRestApiConfigBuilder : IPayamGostarRestApiConfigBuilder
    {
        private readonly PayamGostarApiClientConfig _config;

        public PayamGostarRestApiConfigBuilder(PayamGostarApiClientConfig config)
        {
            _config = config;
        }

        public PayamGostarRestApiConfig Create()
        {
            return new PayamGostarRestApiConfig
            {
                LanguageCulture = _config.LanguageCulture,
                ClientApiIntraction = new ClientInteraction
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