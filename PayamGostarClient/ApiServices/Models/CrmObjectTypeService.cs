using PayamGostarClient.ApiProvider;
using PayamGostarClient.ApiProvider.Abstractions;
using PayamGostarClient.ApiServices.Abstractions;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeServiceDtos.Search;
using PayamGostarClient.ApiServices.Extension;
using PayamGostarClient.Helper.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiServices.Models
{

    public class CrmObjectTypeService : BaseApiService, ICrmObjectTypeService
    {
        private readonly ICrmObjectTypeApiClient _crmObjectTypeClient;

        public CrmObjectTypeService(PayamGostarClientConfig clientConfig, IPayamGostarClientAbstractFactory clientFactory)
            : base(clientConfig, clientFactory)
        {
            _crmObjectTypeClient = ClientFactory.CreateCrmObjectTypeApiClient();
        }

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
