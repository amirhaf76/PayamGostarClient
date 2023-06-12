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
    public class CrmObjectTypeApiService : ICrmObjectTypeApiService
    {
        private readonly ICrmObjectTypeApiClient _crmObjectTypeApiClient;

        private readonly PayamGostarClientConfig _payamGostarClientConfig;

        public CrmObjectTypeApiService(PayamGostarClientConfig payamGostarClientConfig, IPayamGostarClientAbstractFactory clientFactory)
        {
            _payamGostarClientConfig = payamGostarClientConfig;

            _crmObjectTypeApiClient = clientFactory.CreateCrmObjectTypeApiClient();
        }

        public async Task<ApiResponse<IEnumerable<CrmObjectTypeGetResultDto>>> SearchAsync(BaseCrmModelDto request)
        {
            var searchResultTask = _crmObjectTypeApiClient.PostApiV2CrmobjecttypeSearchAsync(request.ConvertToCrmObjectTypeSearchRequestVM());

            var searchResult = await searchResultTask.WrapInThrowableApiServiceException().ConfigureAwait(false);

            return searchResult.ConvertToApiResponse(result => result.Items.Select(crm => crm.ConvertToCrmObjectTypeGetResultDto()));
        }
    }
}
