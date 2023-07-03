using PayamGostarClient.ApiClient.Abstractions.Customization.CrmObjectType;
using PayamGostarClient.ApiClient.ApiProvider.Abstractions;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeInvoiceApiClientDtos.Create;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeInvoiceApiClientDtos.Get;
using PayamGostarClient.ApiClient.Extension;
using PayamGostarClient.ApiProvider;
using PayamGostarClient.Helper.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiClient.Models.Customization.CrmObjectType
{
    internal class PayamGostarCrmObjectTypeInvoiceApiClient : BaseApiClient, IPayamGostarCrmObjectTypeInvoiceApiClient
    {
        private readonly ICrmObjectTypeInvoiceApiClient _invoiceApiClient;

        public PayamGostarCrmObjectTypeInvoiceApiClient(PayamGostarApiClientConfig apiClientConfig, IPayamGostarApiProviderFactory apiProviderFactory) : base(apiClientConfig, apiProviderFactory)
        {
            _invoiceApiClient = apiProviderFactory.CreateCrmObjectTypeInvoiceApiClient();
        }

        public async Task<ApiResponse<CrmObjectTypeResultDto>> CreateAsync(CrmObjectTypeInvoiceCreateRequestDto request)
        {
            try
            {
                var invoiceCreationResult = await _invoiceApiClient.PostApiV2CrmobjecttypeInvoiceCreateAsync(request.ToVM());

                return invoiceCreationResult.ConvertToApiResponse(result => result.ToDto());
            }
            catch (ApiException e)
            {
                throw e.CreateApiServiceException(Helper.Helper.GetStringsFromProperties(request));
            }
        }

        public async Task<ApiResponse<IEnumerable<AdditionalCostsPlacementTypeGetResultDto>>> GetAdditionalCostsPlacementTypeAsync()
        {
            try
            {
                var invoiceCreationResult = await _invoiceApiClient.PostApiV2CrmobjecttypeInvoiceGetadditionalcostsplacementtypeAsync();

                return invoiceCreationResult.ConvertToApiResponse(result => result.Select(x => x.ToDto()));
            }
            catch (ApiException e)
            {
                throw ApiResponseExtension.CreateApiServiceException(e);
            }
        }

        public async Task<ApiResponse<IEnumerable<InvoiceAdditionalCostTypeGetResultDto>>> GetAdditionalCostTypeAsync()
        {
            try
            {
                var invoiceCreationResult = await _invoiceApiClient.PostApiV2CrmobjecttypeInvoiceGetadditionalcosttypeAsync();

                return invoiceCreationResult.ConvertToApiResponse(result => result.Select(x => x.ToDto()));
            }
            catch (ApiException e)
            {
                throw ApiResponseExtension.CreateApiServiceException(e);
            }
        }


    }
}
