using Septa.PayamGostarClient.Initializer.Core.APIs;
using Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.CrmObjectType;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeReturnPurchaseInvoiceApiClientDtos.Create;
using Septa.PayamGostarClient.Initializer.Core.Helper;
using Septa.PayamGostarClient.Initializer.Extension;
using Septa.PayamGostarClient.RestApi;
using Septa.PayamGostarClient.RestApi.Factory;
using System.Threading.Tasks;

namespace Septa.PayamGostarClient.Initializer.Models.Customization.CrmObjectType
{
    public class PayamGostarCrmObjectTypeReturnPurchaseInvoiceApiClient : BaseApiClient, IPayamGostarCrmObjectTypeReturnPurchaseInvoiceApiClient
    {
        private readonly ICrmObjectTypeReturnPurchaseInvoiceApiClient _returnPurchaseInvoiceApiClient;

        public PayamGostarCrmObjectTypeReturnPurchaseInvoiceApiClient(PayamGostarApiClientConfig apiClientConfig, IPayamGostarRestApiClientFactory apiProviderFactory) : base(apiClientConfig, apiProviderFactory)
        {
            _returnPurchaseInvoiceApiClient = ApiProviderFactory.CreateCrmObjectTypeReturnPurchaseInvoiceApiClient();
        }

        public CrmObjectTypeResultDto Create(CrmObjectTypeReturnPurchaseInvoiceCreateRequestDto request)
        {
            return SeptaKit.Extensions.SeptaKitTaskExtensions.RunSync(() => CreateAsync(request));
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
                throw e.CreateApiServiceException(Help.GetStringsFromProperties(request));
            }
        }
    }
}
