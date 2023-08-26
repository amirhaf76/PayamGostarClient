using SeptaPay.PayamGostarClient.Initializer.Core.APIs;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.CrmObjectType;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypePurchaseQuoteApiClientDtos.Create;
using SeptaPay.PayamGostarClient.Initializer.Extension;
using SeptaPay.PayamGostarClient.RestApi;
using SeptaPay.PayamGostarClient.RestApi.Factory;
using System.Threading.Tasks;

namespace SeptaPay.PayamGostarClient.Initializer.Models.Customization.CrmObjectType
{
    public class PayamGostarCrmObjectTypePurchaseQuoteApiClient : BaseApiClient, IPayamGostarCrmObjectTypePurchaseQuoteApiClient
    {
        private readonly ICrmObjectTypePurchaseQuoteApiClient _purchaseQuoteApiClient;

        public PayamGostarCrmObjectTypePurchaseQuoteApiClient(PayamGostarApiClientConfig apiClientConfig, IPayamGostarRestApiClientFactory apiProviderFactory) : base(apiClientConfig, apiProviderFactory)
        {
            _purchaseQuoteApiClient = ApiProviderFactory.CreateCrmObjectTypePurchaseQuoteApiClient();
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
                throw e.CreateApiServiceException(Core.Helper.Help.GetStringsFromProperties(request));
            }
        }
    }
}
