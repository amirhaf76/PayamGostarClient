using PayamGostarClient.ApiProvider.Abstractions;
using System;

namespace PayamGostarClient.ApiProvider
{
    public class PayamGostarClientFactory : IPayamGostarClientAbstractFactory
    {
        private readonly PayamGostarClientConfig _config;

        public PayamGostarClientFactory(PayamGostarClientConfig config)
        {
            _config = config;
        }

        public ICrmObjectTypeApiClient CreateCrmObjectTypeApiClient()
        {
            return CreateClient<ICrmObjectTypeApiClient, CrmObjectTypeApiClient>();
        }

        public ICrmObjectTypeFormApiClient CreateCrmObjectTypeFormApiClientt()
        {
            return CreateClient<ICrmObjectTypeFormApiClient, CrmObjectTypeFormApiClient>();
        }

        public ICrmObjectTypeStageApiClient CreateICrmObjectTypeStageApiClient()
        {
            return CreateClient<ICrmObjectTypeStageApiClient, CrmObjectTypeStageApiClient>();
        }

        public IPropertyDefinitionApiClient CreateIPropertyDefinitionApiClient()
        {
            return CreateClient<IPropertyDefinitionApiClient, PropertyDefinitionApiClient>();
        }

        public IPropertyGroupApiClient CreateIPropertyGroupApiClient()
        {
            return CreateClient<IPropertyGroupApiClient, PropertyGroupApiClient>();
        }

        public TAbstractClient CreateClient<TAbstractClient, TClient>() 
            where TClient: TAbstractClient
        {
            return (TAbstractClient)Activator.CreateInstance(typeof(TClient), _config);
        }
    }
}
