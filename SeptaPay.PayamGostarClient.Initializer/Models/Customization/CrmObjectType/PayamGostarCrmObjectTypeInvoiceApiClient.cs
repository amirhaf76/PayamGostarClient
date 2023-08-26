using SeptaPay.PayamGostarClient.Initializer.Core.APIs;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.CrmObjectType;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeInvoiceApiClientDtos.Create;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeInvoiceApiClientDtos.Get;
using SeptaPay.PayamGostarClient.Initializer.Extension;
using SeptaPay.PayamGostarClient.RestApi;
using SeptaPay.PayamGostarClient.RestApi.Factory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeptaPay.PayamGostarClient.Initializer.Models.Customization.CrmObjectType
{
    internal class PayamGostarCrmObjectTypeInvoiceApiClient : BaseApiClient, IPayamGostarCrmObjectTypeInvoiceApiClient
    {
        private readonly ICrmObjectTypeInvoiceApiClient _invoiceApiClient;

        public PayamGostarCrmObjectTypeInvoiceApiClient(PayamGostarApiClientConfig apiClientConfig, IPayamGostarRestApiClientFactory apiProviderFactory) : base(apiClientConfig, apiProviderFactory)
        {
            _invoiceApiClient = apiProviderFactory.CreateCrmObjectTypeInvoiceApiClient();
        }

        public async Task<CrmObjectTypeResultDto> CreateAsync(CrmObjectTypeInvoiceCreateRequestDto request)
        {
            try
            {
                var invoiceCreationResult = await _invoiceApiClient.PostApiV2CrmobjecttypeInvoiceCreateAsync(request.ToVM());

                return invoiceCreationResult.Result.ToDto();
            }
            catch (ApiException e)
            {
                throw e.CreateApiServiceException(Core.Helper.Help.GetStringsFromProperties(request));
            }
        }

        public async Task<IEnumerable<AdditionalCostsPlacementTypeGetResultDto>> GetAdditionalCostsPlacementTypeAsync()
        {
            try
            {
                var invoiceCreationResult = await _invoiceApiClient.PostApiV2CrmobjecttypeInvoiceGetadditionalcostsplacementtypeAsync();

                return invoiceCreationResult.Result.Select(x => x.ToDto());
            }
            catch (ApiException e)
            {
                throw e.CreateApiServiceException();
            }
        }

        public async Task<IEnumerable<InvoiceAdditionalCostTypeGetResultDto>> GetAdditionalCostTypeAsync()
        {
            try
            {
                var invoiceCreationResult = await _invoiceApiClient.PostApiV2CrmobjecttypeInvoiceGetadditionalcosttypeAsync();

                return invoiceCreationResult.Result.Select(x => x.ToDto());
            }
            catch (ApiException e)
            {
                throw e.CreateApiServiceException();
            }
        }


    }
}
