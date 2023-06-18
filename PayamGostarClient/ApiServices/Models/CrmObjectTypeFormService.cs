using PayamGostarClient.ApiProvider;
using PayamGostarClient.ApiProvider.Abstractions;
using PayamGostarClient.ApiServices.Abstractions;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeFormServiceDtos;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeServiceDtos;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeServiceDtos.Create;
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
            var gettingFormTask = _crmObjectFormClient.PostApiV2CrmobjecttypeFormGetAsync(request.ConvertToCrmObjectTypeGetRequestVM());

            var gettingFormResult = await gettingFormTask.WrapInThrowableApiServiceExceptionAndInvoke().ConfigureAwait(false);

            return gettingFormResult.ConvertToApiResponse(result => result.ToDto());
        }

        public async Task<ApiResponse<CrmObjectTypeResultDto>> CreateAsync(CrmObjectTypeFormCreateRequestDto request)
        {
            var formCreationTask = _crmObjectFormClient
                .PostApiV2CrmobjecttypeFormCreateAsync(request.ToVM());

            var formCreationResult = await formCreationTask.WrapInThrowableApiServiceExceptionAndInvoke().ConfigureAwait(false);

            return formCreationResult.ConvertToApiResponse(result => result.ConvertToCrmObjectTypeResultDto());

        }
    }
}
