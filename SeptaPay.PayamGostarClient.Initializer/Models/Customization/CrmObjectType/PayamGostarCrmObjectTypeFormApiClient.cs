using SeptaPay.PayamGostarClient.Initializer.Core.APIs;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.CrmObjectType;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Get;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeFormApiClientDtos.Create;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeFormApiClientDtos.Gets;
using SeptaPay.PayamGostarClient.Initializer.Extension;
using SeptaPay.PayamGostarClient.RestApi;
using SeptaPay.PayamGostarClient.RestApi.Factory;
using System.Threading.Tasks;

namespace SeptaPay.PayamGostarClient.Initializer.Models.Customization.CrmObjectType
{
    public class PayamGostarCrmObjectTypeFormApiClient : BaseApiClient, IPayamGostarCrmObjectTypeFormApiClient
    {
        private readonly ICrmObjectTypeFormApiClient _crmObjectFormClient;

        public PayamGostarCrmObjectTypeFormApiClient(PayamGostarApiClientConfig apiClientConfig, IPayamGostarRestApiClientFactory apiProviderFactory) : base(apiClientConfig, apiProviderFactory)
        {
            _crmObjectFormClient = apiProviderFactory.CreateCrmObjectTypeFormApiClient();
        }

        public async Task<CrmObjectTypeFormGetResultDto> GetAsync(CrmObjectTypeGetRequestDto request)
        {
            try
            {
                var gettingFormResult = await _crmObjectFormClient.PostApiV2CrmobjecttypeFormGetAsync(request.ToVM());

                return gettingFormResult.Result.ToDto();
            }
            catch (ApiException e)
            {
                throw e.CreateApiServiceException(Core.Helper.Help.GetStringsFromProperties(request));
            }
        }

        public async Task<CrmObjectTypeResultDto> CreateAsync(CrmObjectTypeFormCreateRequestDto request)
        {
            try
            {
                var formCreationResult = await _crmObjectFormClient.PostApiV2CrmobjecttypeFormCreateAsync(request.ToVM());

                return formCreationResult.Result.ToDto();
            }
            catch (ApiException e)
            {
                throw e.CreateApiServiceException(Core.Helper.Help.GetStringsFromProperties(request));
            }

        }
    }
}
