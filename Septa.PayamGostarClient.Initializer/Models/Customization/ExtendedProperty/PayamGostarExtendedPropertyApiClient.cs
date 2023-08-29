using Septa.PayamGostarClient.Initializer.Core.APIs;
using Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.ExtendedProperty;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.ExtendedPropertyApiClientDtos.BaseStructure.Simple;
using Septa.PayamGostarClient.Initializer.Models.Customization.ExtendedProperty.Factory;
using Septa.PayamGostarClient.RestApi;
using Septa.PayamGostarClient.RestApi.Factory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Septa.PayamGostarClient.Initializer.Models.Customization.ExtendedProperty
{
    public class PayamGostarExtendedPropertyApiClient : BaseApiClient, IPayamGostarExtendedPropertyApiClient
    {
        private readonly IPropertyDefinitionApiClient _propertyDefinitionApiClient;
        private readonly ExtendedPropertyCreationFactory _extendedFactory;

        public PayamGostarExtendedPropertyApiClient(PayamGostarApiClientConfig apiClientConfig, IPayamGostarRestApiClientFactory apiProviderFactory) : base(apiClientConfig, apiProviderFactory)
        {
            _propertyDefinitionApiClient = ApiProviderFactory.CreatePropertyDefinitionApiClient();

            _extendedFactory = new ExtendedPropertyCreationFactory(ApiProviderFactory);
        }


        public async Task<PropertyDefinitionCreationResultDto> CreateAsync(BaseExtendedPropertyDto baseProperty)
        {
            var extendedPropertyCreationService = _extendedFactory.Create(baseProperty);

            return await extendedPropertyCreationService.CreateAsync();
        }

        public PropertyDefinitionCreationResultDto Create(BaseExtendedPropertyDto baseProperty)
        {
            return SeptaKit.Extensions.SeptaKitTaskExtensions.RunSync(() => CreateAsync(baseProperty));
        }
    }

    public class ExtendedPropertyValueService : BaseApiClient
    {
        private readonly IDropDownListPropertyDefinitionValueApiClient _clientApi;

        public ExtendedPropertyValueService(PayamGostarApiClientConfig apiClientConfig, IPayamGostarRestApiClientFactory apiProviderFactory) : base(apiClientConfig, apiProviderFactory)
        {
        }

        public Task<IEnumerable<DropDownListValueResultDto>> GetDropDownListValues(DropDownListValueRequestDto request)
        {
            throw new NotImplementedException();
            //try
            //{
            //    var gettingDropdownValues = await _clientApi.PostApiV2DropDownListPropertyDefinitionValueGetAsync(request.ToVM());

            //    return null;
            //}
            //catch (ApiException e)
            //{
            //    throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(Help.GetStringsFromProperties(request), e);
            //}
        }
    }

    public class DropDownListValueRequestDto
    {
        public Guid Id { get; set; }
    }

    public class DropDownListValueResultDto
    {
        public Guid Id { get; set; }

        public Guid? PropertyDefinitionId { get; set; }

        public string Value { get; set; }

        public int Index { get; set; }

        public int? DisplayIndex { get; set; }

    }
}
