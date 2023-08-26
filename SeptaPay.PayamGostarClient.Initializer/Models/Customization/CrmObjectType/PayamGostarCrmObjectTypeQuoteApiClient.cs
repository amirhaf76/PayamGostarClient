using SeptaPay.PayamGostarClient.Initializer.Core.APIs;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.CrmObjectType;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeQuoteApiClientDtos.Create;
using SeptaPay.PayamGostarClient.Initializer.Extension;
using SeptaPay.PayamGostarClient.RestApi;
using SeptaPay.PayamGostarClient.RestApi.Factory;
using System.Threading.Tasks;

namespace SeptaPay.PayamGostarClient.Initializer.Models.Customization.CrmObjectType
{
    public class PayamGostarCrmObjectTypeQuoteApiClient : BaseApiClient, IPayamGostarCrmObjectTypeQuoteApiClient
    {
        private readonly ICrmObjectTypeQuoteApiClient _saleQuoteApiClient;

        public PayamGostarCrmObjectTypeQuoteApiClient(PayamGostarApiClientConfig apiClientConfig, IPayamGostarRestApiClientFactory apiProviderFactory) : base(apiClientConfig, apiProviderFactory)
        {
            _saleQuoteApiClient = apiProviderFactory.CreateCrmObjectTypeQuoteApiClient();
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
                throw e.CreateApiServiceException(Core.Helper.Help.GetStringsFromProperties(request));
            }
        }
    }
}
