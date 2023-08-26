using SeptaPay.PayamGostarClient.Initializer.Core.APIs;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.CrmObjectType;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeReturnInvoiceApiClientDtos.Create;
using SeptaPay.PayamGostarClient.Initializer.Extension;
using SeptaPay.PayamGostarClient.RestApi;
using SeptaPay.PayamGostarClient.RestApi.Factory;
using System.Threading.Tasks;

namespace SeptaPay.PayamGostarClient.Initializer.Models.Customization.CrmObjectType
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
                throw e.CreateApiServiceException(Core.Helper.Help.GetStringsFromProperties(request));
            }
        }
    }
}
