using PayamGostarClient.ApiProvider;
using PayamGostarClient.ApiProvider.Abstractions;
using PayamGostarClient.ApiServices.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiServices.Models
{
    public class ExtendedPropertyService : BaseApiService, IExtendedPropertyService
    {
        private readonly IPropertyDefinitionApiClient _propertyDefinitionApiClient;
        private readonly ITextPropertyDefinitionApiClient _textPropertyApiClient;

        public ExtendedPropertyService(PayamGostarClientConfig clientConfig, IPayamGostarClientAbstractFactory clientFactory) : base(clientConfig, clientFactory)
        {
            _propertyDefinitionApiClient = ClientFactory.CreatePropertyDefinitionApiClient();

            
        }

        public Task<object> CreateAsync(object obj)
        {
            var creationPropertyTask = _textPropertyApiClient.PostApiV2TextpropertydefinitionCreateAsync()
            throw new NotImplementedException();
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
