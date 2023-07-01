using PayamGostarClient.ApiProvider;
using PayamGostarClient.ApiClient.Dtos;
using PayamGostarClient.ApiClient.Extension;
using PayamGostarClient.Helper.Net;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PayamGostarClient.ApiClient.Dtos.ExtendedPropertyApiClientDtos.BaseStructure.Simple;
using PayamGostarClient.ApiClient.ApiProvider.Abstractions;
using PayamGostarClient.ApiClient.Models.Customization.ExtendedProperty.Factory;
using PayamGostarClient.ApiClient.Abstractions.Customization.ExtendedProperty;

namespace PayamGostarClient.ApiClient.Models.Customization.ExtendedProperty
{
    public class PayamGostarExtendedPropertyApiClient : BaseApiClient, IPayamGostarExtendedPropertyApiClient
    {
        private readonly IPropertyDefinitionApiClient _propertyDefinitionApiClient;
        private readonly ExtendedPropertyCreationFactory _extendedFactory;

        public PayamGostarExtendedPropertyApiClient(PayamGostarApiClientConfig apiClientConfig, IPayamGostarApiProviderFactory apiProviderFactory) : base(apiClientConfig, apiProviderFactory)
        {
            _propertyDefinitionApiClient = ApiProviderFactory.CreatePropertyDefinitionApiClient();

            _extendedFactory = new ExtendedPropertyCreationFactory(ApiProviderFactory);
        }




        // Todo: change BaseExtendedPropertyDto to BaseExtendedPropertyCreationDto.
        public async Task<ApiResponse<PropertyDefinitionCreationResultDto>> CreateAsync(BaseExtendedPropertyDto baseProperty)
        {
            var extendedPropertyCreationService = _extendedFactory.Create(baseProperty);

            return await extendedPropertyCreationService.CreateAsync();
        }


    }

    public class ExtendedPropertyValueService : BaseApiClient
    {
        private readonly IDropDownListPropertyDefinitionValueApiClient _clientApi;

        public ExtendedPropertyValueService(PayamGostarApiClientConfig apiClientConfig, IPayamGostarApiProviderFactory apiProviderFactory) : base(apiClientConfig, apiProviderFactory)
        {
        }

        public Task<ApiResponse<IEnumerable<DropDownListValueResultDto>>> GetDropDownListValues(DropDownListValueRequestDto request)
        {
            throw new NotImplementedException();
            //try
            //{
            //    var gettingDropdownValues = await _clientApi.PostApiV2DropDownListPropertyDefinitionValueGetAsync(request.ToVM());

            //    return null;
            //}
            //catch (ApiException e)
            //{
            //    throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(Helper.Helper.GetStringsFromProperties(request), e);
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
