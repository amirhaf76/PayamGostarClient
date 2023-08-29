using Septa.PayamGostarClient.Initializer.Core.APIs;
using Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.CrmObjectType;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypePurchaseQuoteApiClientDtos.Create;
using Septa.PayamGostarClient.Initializer.Core.Helper;
using Septa.PayamGostarClient.Initializer.Extension;
using Septa.PayamGostarClient.RestApi;
using Septa.PayamGostarClient.RestApi.Factory;
using System.Threading.Tasks;

namespace Septa.PayamGostarClient.Initializer.Models.Customization.CrmObjectType
{
    public class PayamGostarCrmObjectTypePurchaseQuoteApiClient : BaseApiClient, IPayamGostarCrmObjectTypePurchaseQuoteApiClient
    {
        private readonly ICrmObjectTypePurchaseQuoteApiClient _purchaseQuoteApiClient;

        public PayamGostarCrmObjectTypePurchaseQuoteApiClient(PayamGostarApiClientConfig apiClientConfig, IPayamGostarRestApiClientFactory apiProviderFactory) : base(apiClientConfig, apiProviderFactory)
        {
            _purchaseQuoteApiClient = ApiProviderFactory.CreateCrmObjectTypePurchaseQuoteApiClient();
        }

        public CrmObjectTypeResultDto Create(CrmObjectTypePurchaseQuoteCreateRequestDto request)
        {
            return SeptaKit.Extensions.SeptaKitTaskExtensions.RunSync(() => CreateAsync(request));
        }

        public async Task<CrmObjectTypeResultDto> CreateAsync(CrmObjectTypePurchaseQuoteCreateRequestDto request)
        {
            try
            {
                var purchaseQuoteCreationResult = await _purchaseQuoteApiClient.PostApiV2CrmobjecttypePurchasequoteCreateAsync(request.ToVM());

                return purchaseQuoteCreationResult.Result.ToDto();
            }
            catch (ApiException e)
            {
                throw e.CreateApiServiceException(Help.GetStringsFromProperties(request));
            }
        }
    }
}
