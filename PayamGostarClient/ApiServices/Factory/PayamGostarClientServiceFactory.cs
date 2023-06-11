using PayamGostarClient.ApiProvider;
using PayamGostarClient.ApiServices.Abstractions;
using PayamGostarClient.ApiServices.Models;
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
            throw new NotImplementedException();
        }

        private static PayamGostarClientFactory CreatePayamGostarClientFactory(PayamGostarClientConfig clientConfig)
        {
            throw new NotImplementedException();
        }

        public ICrmObjectTypeApiService CreateCrmObjectTypeApiService()
        {
            return new CrmObjectTypeApiService(_clientConfig, _clientFactory);
        }
    }
}
