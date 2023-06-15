using PayamGostarClient.ApiProvider;
using PayamGostarClient.ApiProvider.Abstractions;
using PayamGostarClient.ApiServices.Abstractions;
using PayamGostarClient.ApiServices.Dtos;
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
            var searchResultTask = _crmObjectTypeClient.PostApiV2CrmobjecttypeSearchAsync(request.ToVM());

            var searchResult = await searchResultTask.WrapInThrowableApiServiceExceptionAndInvoke().ConfigureAwait(false);

            return searchResult.ConvertToApiResponse(result => result.Items.Select(crm => crm.ToDto()));
        }
    }
}
