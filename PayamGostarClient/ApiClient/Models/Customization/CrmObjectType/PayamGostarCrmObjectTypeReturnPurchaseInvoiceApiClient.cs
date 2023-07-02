using PayamGostarClient.ApiClient.Abstractions.Customization.CrmObjectType;
using PayamGostarClient.ApiClient.ApiProvider.Abstractions;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeReturnPurchaseInvoiceApiClientDtos.Create;
using PayamGostarClient.ApiClient.Extension;
using PayamGostarClient.ApiProvider;
using PayamGostarClient.Helper.Net;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiClient.Models.Customization.CrmObjectType
{
    public class PayamGostarCrmObjectTypeReturnPurchaseInvoiceApiClient : BaseApiClient, IPayamGostarCrmObjectTypeReturnPurchaseInvoiceApiClient
    {
        private readonly ICrmObjectTypeReturnPurchaseInvoiceApiClient _returnPurchaseInvoiceApiClient;

        public PayamGostarCrmObjectTypeReturnPurchaseInvoiceApiClient(PayamGostarApiClientConfig apiClientConfig, IPayamGostarApiProviderFactory apiProviderFactory) : base(apiClientConfig, apiProviderFactory)
        {
            _returnPurchaseInvoiceApiClient = ApiProviderFactory.CreateCrmObjectTypeReturnPurchaseInvoiceApiClient();
        }

        public async Task<ApiResponse<CrmObjectTypeResultDto>> CreateAsync(CrmObjectTypeReturnPurchaseInvoiceCreateRequestDto request)
        {
            try
            {
                var creationResult = await _returnPurchaseInvoiceApiClient.PostApiV2CrmobjecttypeReturnpurchaseinvoiceCreateAsync(request.ToVM());

                return creationResult.ConvertToApiResponse(result => result.ToDto());
            }
            catch (ApiException e)
            {
                throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(Helper.Helper.GetStringsFromProperties(request), e);
            }
        }
    }
}
