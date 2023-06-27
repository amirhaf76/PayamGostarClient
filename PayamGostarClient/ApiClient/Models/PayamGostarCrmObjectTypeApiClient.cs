using PayamGostarClient.ApiProvider;
using PayamGostarClient.ApiProvider.Abstractions;
using PayamGostarClient.ApiClient.Abstractions;
using PayamGostarClient.ApiClient.Dtos.CrmObjectTypeServiceDtos.Search;
using PayamGostarClient.ApiClient.Extension;
using PayamGostarClient.ApiClient.Factory;
using PayamGostarClient.Helper.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiClient.Models
{

    public class PayamGostarCrmObjectTypeApiClient : BaseApiClient, IPayamGostarCrmObjectTypeApiClient
    {
        private readonly ICrmObjectTypeApiClient _crmObjectTypeClient;

        public PayamGostarCrmObjectTypeApiClient(PayamGostarApiClientConfig apiClientConfig, IPayamGostarApiProviderFactory apiProviderFactory) : base(apiClientConfig, apiProviderFactory)
        {
            _crmObjectTypeClient = ApiProviderFactory.CreateCrmObjectTypeApiClient();
        }

        public IPayamGostarCrmObjectTypeFormApiClient FormApi => new PayamGostarCrmObjectTypeFormApiClient(ApiClientConfig, ApiProviderFactory);

        public IPayamGostarCrmObjectTypeStageApiClient StageApi => new PayamGostarCrmObjectTypeStageApiClient(ApiClientConfig, ApiProviderFactory);

        public IPayamGostarCrmObjectTypeTicketApiClient TicketApi => new PayamGostarCrmObjectTypeTicketApiClient(ApiClientConfig, ApiProviderFactory);

        public async Task<ApiResponse<IEnumerable<CrmObjectTypeSearchResultDto>>> SearchAsync(CrmObjectTypeSearchRequestDto request)
        {
            try
            {
                var searchResult = await _crmObjectTypeClient.PostApiV2CrmobjecttypeSearchAsync(request.ToVM());

                return searchResult.ConvertToApiResponse(result => result.Items.Select(crm => crm.ToDto()));
            }
            catch (ApiException e)
            {
                throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(Helper.Helper.GetStringsFromProperties(request), e);
            }

        }
    }

  
}
