using Septa.PayamGostarClient.Initializer.Core.APIs;
using Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.CrmObjectType;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Get;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeFormApiClientDtos.Create;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeFormApiClientDtos.Gets;
using Septa.PayamGostarClient.Initializer.Core.Helper;
using Septa.PayamGostarClient.Initializer.Extension;
using Septa.PayamGostarClient.RestApi;
using Septa.PayamGostarClient.RestApi.Factory;
using System.Threading.Tasks;

namespace Septa.PayamGostarClient.Initializer.Models.Customization.CrmObjectType
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
                throw e.CreateApiServiceException(Help.GetStringsFromProperties(request));
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
                throw e.CreateApiServiceException(Help.GetStringsFromProperties(request));
            }

        }

        public CrmObjectTypeFormGetResultDto Get(CrmObjectTypeGetRequestDto request)
        {
            return SeptaKit.Extensions.SeptaKitTaskExtensions.RunSync(() => GetAsync(request));
        }

        public CrmObjectTypeResultDto Create(CrmObjectTypeFormCreateRequestDto request)
        {
            return SeptaKit.Extensions.SeptaKitTaskExtensions.RunSync(() => CreateAsync(request));
        }
    }
}
