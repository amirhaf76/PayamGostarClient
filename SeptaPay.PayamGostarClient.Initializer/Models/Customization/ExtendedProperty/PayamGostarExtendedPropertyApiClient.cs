using SeptaPay.PayamGostarClient.Initializer.Core.APIs;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.ExtendedProperty;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.ExtendedPropertyApiClientDtos.BaseStructure.Simple;
using SeptaPay.PayamGostarClient.Initializer.Models.Customization.ExtendedProperty.Factory;
using SeptaPay.PayamGostarClient.RestApi;
using SeptaPay.PayamGostarClient.RestApi.Factory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SeptaPay.PayamGostarClient.Initializer.Models.Customization.ExtendedProperty
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




        // Todo: change BaseExtendedPropertyDto to BaseExtendedPropertyCreationDto.
        public async Task<PropertyDefinitionCreationResultDto> CreateAsync(BaseExtendedPropertyDto baseProperty)
        {
            var extendedPropertyCreationService = _extendedFactory.Create(baseProperty);

            return await extendedPropertyCreationService.CreateAsync();
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
            //    throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(Core.Helper.Help.GetStringsFromProperties(request), e);
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
