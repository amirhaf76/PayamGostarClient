using PayamGostarClient.ApiProvider;
using PayamGostarClient.ApiProvider.Abstractions;
using PayamGostarClient.ApiServices.Abstractions;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeFormServiceDtos.Create;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeFormServiceDtos.Gets;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeServiceDtos;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeServiceDtos.Get;
using PayamGostarClient.ApiServices.Extension;
using PayamGostarClient.Helper.Net;
using System;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiServices.Models
{
    public class CrmObjectTypeFormService : BaseApiService, ICrmObjectTypeFormService
    {
        private readonly ICrmObjectTypeFormApiClient _crmObjectFormClient;

        public CrmObjectTypeFormService(PayamGostarClientConfig config, IPayamGostarClientAbstractFactory clientFactory)
            : base(config, clientFactory)
        {
            _crmObjectFormClient = ClientFactory.CreateCrmObjectTypeFormApiClientt();
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
