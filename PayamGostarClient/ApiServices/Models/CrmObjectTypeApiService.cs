using PayamGostarClient.ApiProvider;
using PayamGostarClient.ApiServices.Abstractions;
using PayamGostarClient.ApiServices.Dtos;
using PayamGostarClient.ApiServices.Extension;
using PayamGostarClient.Helper.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiServices.Models
{
    public class CrmObjectTypeApiService : ICrmObjectTypeApiService
    {
        private readonly ICrmObjectTypeApiClient _crmObjectTypeApiClient;

        private readonly PayamGostarClientConfig _payamGostarClientConfig;

        public CrmObjectTypeApiService(PayamGostarClientConfig payamGostarClientConfig, ICrmObjectTypeApiClient crmObjectTypeApiClient)
        {
            _payamGostarClientConfig = payamGostarClientConfig;
            _crmObjectTypeApiClient = crmObjectTypeApiClient;
        }

        public async Task<ApiResponse<IEnumerable<CrmObjectTypeGetResultDto>>> SearchAsync(CrmObjectTypeSearchRequestVM request)
        {
            var searchResult = await _crmObjectTypeApiClient.PostApiV2CrmobjecttypeSearchAsync(request);

            return searchResult.ConvertToApiResponse(result => result.Select(crm => crm.ConvertToCrmObjectTypeGetResultDto()));
        }
    }
}
