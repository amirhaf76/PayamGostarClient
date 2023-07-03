using PayamGostarClient.ApiClient.Abstractions.Customization.CrmObjectType;
using PayamGostarClient.ApiClient.ApiProvider.Abstractions;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeReturnInvoiceApiClientDtos.Create;
using PayamGostarClient.ApiClient.Extension;
using PayamGostarClient.ApiProvider;
using PayamGostarClient.Helper.Net;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiClient.Models.Customization.CrmObjectType
{
    public class PayamGostarCrmObjectTypeReturnInvoiceApiClient : BaseApiClient, IPayamGostarCrmObjectTypeReturnInvoiceApiClient
    {
        private readonly ICrmObjectTypeReturnSaleInvoiceApiClient _saleInvoiceApiClient;

        public PayamGostarCrmObjectTypeReturnInvoiceApiClient(PayamGostarApiClientConfig apiClientConfig, IPayamGostarApiProviderFactory apiProviderFactory) : base(apiClientConfig, apiProviderFactory)
        {
            _saleInvoiceApiClient = ApiProviderFactory.CreateCrmObjectTypeReturnSaleInvoiceApiClient();
        }

        public async Task<ApiResponse<CrmObjectTypeResultDto>> CreateAsync(CrmObjectTypeReturnSaleInvoiceCreateRequestDto request)
        {
            try
            {
                var invoiceCreationResult = await _saleInvoiceApiClient.PostApiV2CrmobjecttypeReturnsaleinvoiceCreateAsync(request.ToVM());

                return invoiceCreationResult.ConvertToApiResponse(result => result.ToDto());
            }
            catch (ApiException e)
            {
                throw e.CreateApiServiceException(Helper.Helper.GetStringsFromProperties(request));
            }
        }
    }
}
