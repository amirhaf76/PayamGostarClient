using PayamGostarClient.ApiProvider;
using PayamGostarClient.ApiProvider.Factory;
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
                    JwtToken = serviceConfig.JwToken,
                    // DeviceId
                    // ClientId
                },
            };
        }

        private static PayamGostarClientFactory CreatePayamGostarClientFactory(PayamGostarClientConfig clientConfig)
        {
            return new PayamGostarClientFactory(clientConfig);
        }


        public ICrmObjectTypeService CreateCrmObjectTypeService()
        {
            return CreateService<ICrmObjectTypeService, CrmObjectTypeService>();
        }

        public ICrmObjectTypeFormService CreateCrmObjectTypeFormService()
        {
            return CreateService<ICrmObjectTypeFormService, CrmObjectTypeFormService>();
        }

        public ICrmObjectTypeTicketService CreateCrmObjectTypeTicketService()
        {
            return CreateService<ICrmObjectTypeTicketService, CrmObjectTypeTicketService>();
        }

        public IExtendedPropertyService CreateExtendedPropertyService()
        {
            return CreateService<IExtendedPropertyService, ExtendedPropertyService>();
        }

        public IPropertyGroupService CreatePropertyGroupService()
        {
            return CreateService<IPropertyGroupService, PropertyGroupService>();
        }

        public ICrmObjectTypeStageService CreateCrmObjectTypeStageService()
        {
            return CreateService<ICrmObjectTypeStageService, CrmObjectTypeStageService>();
        }


        public TAbstactService CreateService<TAbstactService, TService>()
            where TService : BaseApiService, TAbstactService
        {
            return (TAbstactService) Activator.CreateInstance(typeof(TService), _clientConfig, _clientFactory);
        }

        
    }
}
