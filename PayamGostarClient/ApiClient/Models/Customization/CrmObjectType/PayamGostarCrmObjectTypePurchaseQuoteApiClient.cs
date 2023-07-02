using PayamGostarClient.ApiClient.Abstractions.Customization.CrmObjectType;
using PayamGostarClient.ApiClient.ApiProvider.Abstractions;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypePurchaseQuoteApiClientDtos.Create;
using PayamGostarClient.ApiClient.Extension;
using PayamGostarClient.ApiProvider;
using PayamGostarClient.Helper.Net;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiClient.Models.Customization.CrmObjectType
{
    public class PayamGostarCrmObjectTypePurchaseQuoteApiClient : BaseApiClient, IPayamGostarCrmObjectTypePurchaseQuoteApiClient
    {
        private readonly ICrmObjectTypePurchaseQuoteApiClient _purchaseQuoteApiClient;

        public PayamGostarCrmObjectTypePurchaseQuoteApiClient(PayamGostarApiClientConfig apiClientConfig, IPayamGostarApiProviderFactory apiProviderFactory) : base(apiClientConfig, apiProviderFactory)
        {
            _purchaseQuoteApiClient = ApiProviderFactory.CreateCrmObjectTypePurchaseQuoteApiClient();
        }

        public async Task<ApiResponse<CrmObjectTypeResultDto>> CreateAsync(CrmObjectTypePurchaseQuoteCreateRequestDto request)
        {
            try
            {
                var purchaseQuoteCreationResult = await _purchaseQuoteApiClient.PostApiV2CrmobjecttypePurchasequoteCreateAsync(request.ToVM());

                return purchaseQuoteCreationResult.ConvertToApiResponse(result => result.ToDto());
            }
            catch (ApiException e)
            {
                throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(Helper.Helper.GetStringsFromProperties(request), e);
            }
        }
    }
}
