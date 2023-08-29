using Septa.PayamGostarClient.Initializer.Core.APIs;
using Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.CrmObjectType;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypePurchaseInvoiceApiClientDtos.Create;
using Septa.PayamGostarClient.Initializer.Core.Helper;
using Septa.PayamGostarClient.Initializer.Extension;
using Septa.PayamGostarClient.RestApi;
using Septa.PayamGostarClient.RestApi.Factory;
using System.Threading.Tasks;

namespace Septa.PayamGostarClient.Initializer.Models.Customization.CrmObjectType
{
    public class PayamGostarCrmObjectTypePurchaseInvoiceApiClient : BaseApiClient, IPayamGostarCrmObjectTypePurchaseInvoiceApiClient
    {
        private readonly ICrmObjectTypePurchaseInvoiceApiClient _purchaseInvoiceApiClient;

        public PayamGostarCrmObjectTypePurchaseInvoiceApiClient(PayamGostarApiClientConfig apiClientConfig, IPayamGostarRestApiClientFactory apiProviderFactory) : base(apiClientConfig, apiProviderFactory)
        {
            _purchaseInvoiceApiClient = ApiProviderFactory.CreateCrmObjectTypePurchaseInvoiceApiClient();
        }

        public CrmObjectTypeResultDto Create(CrmObjectTypePurchaseInvoiceCreateRequestDto request)
        {
            return SeptaKit.Extensions.SeptaKitTaskExtensions.RunSync(() => CreateAsync(request));
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
                throw e.CreateApiServiceException(Help.GetStringsFromProperties(request));
            }
        }
    }
}
