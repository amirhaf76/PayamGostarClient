using PayamGostarClient.ApiProvider;
using PayamGostarClient.ApiProvider.Abstractions;
using PayamGostarClient.ApiClient.Abstractions;
using PayamGostarClient.ApiClient.Dtos.CrmObjectTypeFormServiceDtos.Create;
using PayamGostarClient.ApiClient.Dtos.CrmObjectTypeFormServiceDtos.Gets;
using PayamGostarClient.ApiClient.Dtos.CrmObjectTypeServiceDtos;
using PayamGostarClient.ApiClient.Dtos.CrmObjectTypeServiceDtos.Get;
using PayamGostarClient.ApiClient.Extension;
using PayamGostarClient.Helper.Net;
using System;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiClient.Models
{
    public class PayamGostarCrmObjectTypeFormApiClient : BaseApiClient, IPayamGostarCrmObjectTypeFormApiClient
    {
        private readonly ICrmObjectTypeFormApiClient _crmObjectFormClient;

        public PayamGostarCrmObjectTypeFormApiClient(PayamGostarApiClientConfig apiClientConfig, IPayamGostarApiProviderFactory apiProviderFactory) : base(apiClientConfig, apiProviderFactory)
        {
            _crmObjectFormClient = apiProviderFactory.CreateCrmObjectTypeFormApiClient();
        }

        public async Task<ApiResponse<CrmObjectTypeFormGetResultDto>> GetAsync(CrmObjectTypeGetRequestDto request)
        {
            try
            {
                var gettingFormResult = await _crmObjectFormClient.PostApiV2CrmobjecttypeFormGetAsync(request.ConvertToCrmObjectTypeGetRequestVM());

                return gettingFormResult.ConvertToApiResponse(result => result.ToDto());
            }
            catch (ApiException e)
            {
               throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(Helper.Helper.GetStringsFromProperties(request),e);
            }
        }

        public async Task<ApiResponse<CrmObjectTypeResultDto>> CreateAsync(CrmObjectTypeFormCreateRequestDto request)
        {
            try
            {
                var formCreationResult = await _crmObjectFormClient.PostApiV2CrmobjecttypeFormCreateAsync(request.ToVM());

                return formCreationResult.ConvertToApiResponse(result => result.ConvertToCrmObjectTypeResultDto());
            }
            catch (ApiException e)
            {
                throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(Helper.Helper.GetStringsFromProperties(request),e);
            }

        }
    }
}
