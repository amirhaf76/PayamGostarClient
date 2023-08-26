using SeptaPay.PayamGostarClient.Initializer.Core.APIs;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.CrmObjectType;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeReturnPurchaseInvoiceApiClientDtos.Create;
using SeptaPay.PayamGostarClient.Initializer.Extension;
using SeptaPay.PayamGostarClient.RestApi;
using SeptaPay.PayamGostarClient.RestApi.Factory;
using System.Threading.Tasks;

namespace SeptaPay.PayamGostarClient.Initializer.Models.Customization.CrmObjectType
{
    public class PayamGostarCrmObjectTypeReturnPurchaseInvoiceApiClient : BaseApiClient, IPayamGostarCrmObjectTypeReturnPurchaseInvoiceApiClient
    {
        private readonly ICrmObjectTypeReturnPurchaseInvoiceApiClient _returnPurchaseInvoiceApiClient;

        public PayamGostarCrmObjectTypeReturnPurchaseInvoiceApiClient(PayamGostarApiClientConfig apiClientConfig, IPayamGostarRestApiClientFactory apiProviderFactory) : base(apiClientConfig, apiProviderFactory)
        {
            _returnPurchaseInvoiceApiClient = ApiProviderFactory.CreateCrmObjectTypeReturnPurchaseInvoiceApiClient();
        }

        public async Task<CrmObjectTypeResultDto> CreateAsync(CrmObjectTypeReturnPurchaseInvoiceCreateRequestDto request)
        {
            try
            {
                var creationResult = await _returnPurchaseInvoiceApiClient.PostApiV2CrmobjecttypeReturnpurchaseinvoiceCreateAsync(request.ToVM());

                return creationResult.Result.ToDto();
            }
            catch (ApiException e)
            {
                throw e.CreateApiServiceException(Core.Helper.Help.GetStringsFromProperties(request));
            }
        }
    }
}
