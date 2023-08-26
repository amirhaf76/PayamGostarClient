using SeptaPay.PayamGostarClient.Initializer.Core.APIs;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.CrmObjectType;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeReceiptApiClientDtos.Create;
using SeptaPay.PayamGostarClient.Initializer.Extension;
using SeptaPay.PayamGostarClient.RestApi;
using SeptaPay.PayamGostarClient.RestApi.Factory;
using System.Threading.Tasks;

namespace SeptaPay.PayamGostarClient.Initializer.Models.Customization.CrmObjectType
{
    public class PayamGostarCrmObjectTypeReceiptApiClient : BaseApiClient, IPayamGostarCrmObjectTypeReceiptApiClient
    {
        private readonly ICrmObjectTypeReceiptApiClient _receiptApiClient;

        public PayamGostarCrmObjectTypeReceiptApiClient(PayamGostarApiClientConfig apiClientConfig, IPayamGostarRestApiClientFactory apiProviderFactory) : base(apiClientConfig, apiProviderFactory)
        {
            _receiptApiClient = ApiProviderFactory.CreateCrmObjectTypeReceiptApiClient();
        }

        public async Task<CrmObjectTypeResultDto> CreateAsync(CrmObjectTypeReceiptCreateRequestDto request)
        {
            try
            {
                var recepitCreationResult = await _receiptApiClient.PostApiV2CrmobjecttypeReceiptCreateAsync(request.ToVM());

                return recepitCreationResult.Result.ToDto();
            }
            catch (ApiException e)
            {
                throw e.CreateApiServiceException(Core.Helper.Help.GetStringsFromProperties(request));
            }
        }
    }
}
