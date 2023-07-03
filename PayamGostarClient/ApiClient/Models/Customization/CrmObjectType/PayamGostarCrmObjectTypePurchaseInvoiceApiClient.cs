using PayamGostarClient.ApiClient.Abstractions.Customization.CrmObjectType;
using PayamGostarClient.ApiClient.ApiProvider.Abstractions;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypePurchaseInvoiceApiClientDtos.Create;
using PayamGostarClient.ApiClient.Extension;
using PayamGostarClient.ApiProvider;
using PayamGostarClient.Helper.Net;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiClient.Models.Customization.CrmObjectType
{
    public class PayamGostarCrmObjectTypePurchaseInvoiceApiClient : BaseApiClient, IPayamGostarCrmObjectTypePurchaseInvoiceApiClient
    {
        private readonly ICrmObjectTypePurchaseInvoiceApiClient _purchaseInvoiceApiClient;

        public PayamGostarCrmObjectTypePurchaseInvoiceApiClient(PayamGostarApiClientConfig apiClientConfig, IPayamGostarApiProviderFactory apiProviderFactory) : base(apiClientConfig, apiProviderFactory)
        {
            _purchaseInvoiceApiClient = ApiProviderFactory.CreateCrmObjectTypePurchaseInvoiceApiClient();
        }

        public async Task<ApiResponse<CrmObjectTypeResultDto>> CreateAsync(CrmObjectTypePurchaseInvoiceCreateRequestDto request)
        {
            try
            {
                var purchaseInvoiceCreationResult = await _purchaseInvoiceApiClient.PostApiV2CrmobjecttypePurchaseinvoiceCreateAsync(request.ToVM());

                return purchaseInvoiceCreationResult.ConvertToApiResponse(result => result.ToDto());
            }
            catch (ApiException e)
            {
                throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(Helper.Helper.GetStringsFromProperties(request), e);
            }
        }
    }
}
