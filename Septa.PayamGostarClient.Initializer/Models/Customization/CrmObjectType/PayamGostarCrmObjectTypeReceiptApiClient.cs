using Septa.PayamGostarClient.Initializer.Core.APIs;
using Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.CrmObjectType;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeReceiptApiClientDtos.Create;
using Septa.PayamGostarClient.Initializer.Core.Helper;
using Septa.PayamGostarClient.Initializer.Extension;
using Septa.PayamGostarClient.RestApi;
using Septa.PayamGostarClient.RestApi.Factory;
using System.Threading.Tasks;

namespace Septa.PayamGostarClient.Initializer.Models.Customization.CrmObjectType
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
                throw e.CreateApiServiceException(Help.GetStringsFromProperties(request));
            }
        }
    }
}
