using Septa.PayamGostarClient.Initializer.Core.APIs;
using Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.CrmObjectType;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeInvoiceApiClientDtos.Create;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeInvoiceApiClientDtos.Get;
using Septa.PayamGostarClient.Initializer.Core.Helper;
using Septa.PayamGostarClient.Initializer.Extension;
using Septa.PayamGostarClient.RestApi;
using Septa.PayamGostarClient.RestApi.Factory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Septa.PayamGostarClient.Initializer.Models.Customization.CrmObjectType
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
                throw e.CreateApiServiceException(Help.GetStringsFromProperties(request));
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
