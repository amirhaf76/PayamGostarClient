using Septa.PayamGostarClient.Initializer.Core.APIs;
using Septa.PayamGostarClient.RestApi;
using Septa.PayamGostarClient.RestApi.ClientInteractions;

namespace Septa.PayamGostarClient.Initializer.Models.RestApiConfigBuilder
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