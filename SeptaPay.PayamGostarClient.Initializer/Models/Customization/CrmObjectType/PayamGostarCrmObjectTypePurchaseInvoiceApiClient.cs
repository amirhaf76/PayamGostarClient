using SeptaPay.PayamGostarClient.Initializer.Core.APIs;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.CrmObjectType;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypePurchaseInvoiceApiClientDtos.Create;
using SeptaPay.PayamGostarClient.Initializer.Extension;
using SeptaPay.PayamGostarClient.RestApi;
using SeptaPay.PayamGostarClient.RestApi.Factory;
using System.Threading.Tasks;

namespace SeptaPay.PayamGostarClient.Initializer.Models.Customization.CrmObjectType
{
    public class PayamGostarCrmObjectTypePurchaseInvoiceApiClient : BaseApiClient, IPayamGostarCrmObjectTypePurchaseInvoiceApiClient
    {
        private readonly ICrmObjectTypePurchaseInvoiceApiClient _purchaseInvoiceApiClient;

        public PayamGostarCrmObjectTypePurchaseInvoiceApiClient(PayamGostarApiClientConfig apiClientConfig, IPayamGostarRestApiClientFactory apiProviderFactory) : base(apiClientConfig, apiProviderFactory)
        {
            _purchaseInvoiceApiClient = ApiProviderFactory.CreateCrmObjectTypePurchaseInvoiceApiClient();
        }

        public async Task<CrmObjectTypeResultDto> CreateAsync(CrmObjectTypePurchaseInvoiceCreateRequestDto request)
        {
            try
            {
                var purchaseInvoiceCreationResult = await _purchaseInvoiceApiClient.PostApiV2CrmobjecttypePurchaseinvoiceCreateAsync(request.ToVM());

                return purchaseInvoiceCreationResult.Result.ToDto();
            }
            catch (ApiException e)
            {
                throw e.CreateApiServiceException(Core.Helper.Help.GetStringsFromProperties(request));
            }
        }
    }
}
