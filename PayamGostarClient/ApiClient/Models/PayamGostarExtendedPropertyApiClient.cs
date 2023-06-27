using PayamGostarClient.ApiProvider;
using PayamGostarClient.ApiProvider.Abstractions;
using PayamGostarClient.ApiClient.Abstractions;
using PayamGostarClient.ApiClient.Dtos;
using PayamGostarClient.ApiClient.Dtos.ExtendedPropertyServiceDtos.BaseStructure.Simple;
using PayamGostarClient.ApiClient.Extension;
using PayamGostarClient.ApiClient.Factory;
using PayamGostarClient.Helper.Net;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiClient.Models
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
