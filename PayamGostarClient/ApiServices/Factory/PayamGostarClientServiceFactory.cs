using PayamGostarClient.ApiProvider;
using PayamGostarClient.ApiServices.Abstractions;
using PayamGostarClient.ApiServices.Models;
using PayamGostarClient.Helper.Net;
using System;

namespace PayamGostarClient.ApiServices.Factory
{
    public class PayamGostarClientServiceFactory : IPayamGostarClientServiceFactory
    {
        private readonly PayamGostarClientServiceConfig _serviceConfig;
        private readonly PayamGostarClientConfig _clientConfig;
        private readonly PayamGostarClientFactory _clientFactory;

        public PayamGostarClientServiceFactory(PayamGostarClientServiceConfig serviceConfig)
        {
            _serviceConfig = serviceConfig;

            _clientConfig = CreateClientConfig(_serviceConfig);

            _clientFactory = CreatePayamGostarClientFactory(_clientConfig);
        }

        private PayamGostarClientConfig CreateClientConfig(PayamGostarClientServiceConfig serviceConfig)
        {
            return new PayamGostarClientConfig
            {
                LanguageCulture = serviceConfig.LanguageCulture,
                ClientApiIntraction = new ClientApiIntraction
                {
                    DomainUrl = serviceConfig.Url,
                    // JwtToken
                    // DeviceId
                    // ClientId
                },
            };
        }

        private static PayamGostarClientFactory CreatePayamGostarClientFactory(PayamGostarClientConfig clientConfig)
        {
            return new PayamGostarClientFactory(clientConfig);
        }

        public ICrmObjectTypeApiService CreateCrmObjectTypeApiService()
        {
            return new CrmObjectTypeApiService(_clientConfig, _clientFactory);
        }
    }
}
