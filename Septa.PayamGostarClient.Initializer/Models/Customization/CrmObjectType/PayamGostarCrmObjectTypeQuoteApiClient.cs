using Septa.PayamGostarClient.Initializer.Core.APIs;
using Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.CrmObjectType;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeQuoteApiClientDtos.Create;
using Septa.PayamGostarClient.Initializer.Core.Helper;
using Septa.PayamGostarClient.Initializer.Extension;
using Septa.PayamGostarClient.RestApi;
using Septa.PayamGostarClient.RestApi.Factory;
using System.Threading.Tasks;

namespace Septa.PayamGostarClient.Initializer.Models.Customization.CrmObjectType
{
    public class PayamGostarCrmObjectTypeQuoteApiClient : BaseApiClient, IPayamGostarCrmObjectTypeQuoteApiClient
    {
        private readonly ICrmObjectTypeQuoteApiClient _saleQuoteApiClient;

        public PayamGostarCrmObjectTypeQuoteApiClient(PayamGostarApiClientConfig apiClientConfig, IPayamGostarRestApiClientFactory apiProviderFactory) : base(apiClientConfig, apiProviderFactory)
        {
            _saleQuoteApiClient = apiProviderFactory.CreateCrmObjectTypeQuoteApiClient();
        }

        public CrmObjectTypeResultDto Create(CrmObjectTypeQuoteCreateRequestDto request)
        {
            return SeptaKit.Extensions.SeptaKitTaskExtensions.RunSync(() => CreateAsync(request));
        }

        public async Task<CrmObjectTypeResultDto> CreateAsync(CrmObjectTypeQuoteCreateRequestDto request)
        {
            try
            {
                var quoteCreationResult = await _saleQuoteApiClient.PostApiV2CrmobjecttypeQuoteCreateAsync(request.ToVM());

                return quoteCreationResult.Result.ToDto();
            }
            catch (ApiException e)
            {
                throw e.CreateApiServiceException(Help.GetStringsFromProperties(request));
            }
        }
    }
}
