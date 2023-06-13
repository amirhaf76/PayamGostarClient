using PayamGostarClient.ApiProvider;
using PayamGostarClient.ApiProvider.Abstractions;
using PayamGostarClient.ApiServices.Abstractions;
using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.BaseStructure.Simple;
using PayamGostarClient.ApiServices.Factory;
using System;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiServices.Models
{
    public class ExtendedPropertyService : BaseApiService, IExtendedPropertyService
    {
        private readonly IPropertyDefinitionApiClient _propertyDefinitionApiClient;
        private readonly ExtendedPropertyCreationFactory _extendedFactory;


        public ExtendedPropertyService(PayamGostarClientConfig clientConfig, IPayamGostarClientAbstractFactory clientFactory) : base(clientConfig, clientFactory)
        {
            _propertyDefinitionApiClient = ClientFactory.CreatePropertyDefinitionApiClient();

            _extendedFactory = new ExtendedPropertyCreationFactory(clientFactory); 
        }


        public async Task<object> CreateAsync(BaseExtendedPropertyDto baseProperty)
        {
            var extendedPropertyCreationService = _extendedFactory.Create(baseProperty);

            return await extendedPropertyCreationService.CreateAsync();
        }
    }

    public class PropertyGroupService : BaseApiService, IPropertyGroupService
    {
        private readonly IPropertyGroupApiClient _propertyGroupApiClient;

        public PropertyGroupService(PayamGostarClientConfig clientConfig, IPayamGostarClientAbstractFactory clientFactory) : base(clientConfig, clientFactory)
        {
            _propertyGroupApiClient = ClientFactory.CreatePropertyGroupApiClient();
        }

        public Task<object> CreateAsync(object obj)
        {
            throw new NotImplementedException();
        }
    }

    public class CrmObjectTypeStageService : BaseApiService, ICrmObjectTypeStageService
    {
        private readonly ICrmObjectTypeStageApiClient _crmObjectTypeStageApiClient;

        public CrmObjectTypeStageService(PayamGostarClientConfig clientConfig, IPayamGostarClientAbstractFactory clientFactory) : base(clientConfig, clientFactory)
        {
            _crmObjectTypeStageApiClient = ClientFactory.CreateCrmObjectTypeStageApiClient();
        }

        public Task<object> CreateAsync(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
