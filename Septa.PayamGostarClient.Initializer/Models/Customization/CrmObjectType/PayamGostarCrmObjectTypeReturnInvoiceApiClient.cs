using Septa.PayamGostarClient.Initializer.Core.APIs;
using Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.CrmObjectType;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeReturnInvoiceApiClientDtos.Create;
using Septa.PayamGostarClient.Initializer.Core.Helper;
using Septa.PayamGostarClient.Initializer.Extension;
using Septa.PayamGostarClient.RestApi;
using Septa.PayamGostarClient.RestApi.Factory;
using System.Threading.Tasks;

namespace Septa.PayamGostarClient.Initializer.Models.Customization.CrmObjectType
{
    public class PayamGostarCrmObjectTypeReturnInvoiceApiClient : BaseApiClient, IPayamGostarCrmObjectTypeReturnInvoiceApiClient
    {
        private readonly ICrmObjectTypeReturnSaleInvoiceApiClient _saleInvoiceApiClient;

        public PayamGostarCrmObjectTypeReturnInvoiceApiClient(PayamGostarApiClientConfig apiClientConfig, IPayamGostarRestApiClientFactory apiProviderFactory) : base(apiClientConfig, apiProviderFactory)
        {
            _saleInvoiceApiClient = ApiProviderFactory.CreateCrmObjectTypeReturnSaleInvoiceApiClient();
        }

        public async Task<CrmObjectTypeResultDto> CreateAsync(CrmObjectTypeReturnSaleInvoiceCreateRequestDto request)
        {
            try
            {
                var invoiceCreationResult = await _saleInvoiceApiClient.PostApiV2CrmobjecttypeReturnsaleinvoiceCreateAsync(request.ToVM());

                return invoiceCreationResult.Result.ToDto();
            }
            catch (ApiException e)
            {
                throw e.CreateApiServiceException(Help.GetStringsFromProperties(request));
            }
        }
    }
}
