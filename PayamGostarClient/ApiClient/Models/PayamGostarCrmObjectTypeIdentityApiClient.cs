using PayamGostarClient.ApiProvider;
using PayamGostarClient.ApiProvider.Abstractions;
using PayamGostarClient.ApiClient.Abstractions;
using PayamGostarClient.ApiClient.Dtos.CrmObjectTypeServiceDtos;
using PayamGostarClient.ApiClient.Extension;
using PayamGostarClient.Helper.Net;
using System.Threading.Tasks;
using PayamGostarClient.ApiClient.Dtos.CrmObjectTypeIdentityApiClientDtos.Create;
using System.Linq;
using System.Collections.Generic;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeIdentityApiClientDtos.Get;

namespace PayamGostarClient.ApiClient.Models
{
    internal class PayamGostarCrmObjectTypeIdentityApiClient : BaseApiClient, IPayamGostarCrmObjectTypeIdentityApiClient
    {
        private readonly ICrmObjectTypeIdentityApiClient _identityApiClient;

        public PayamGostarCrmObjectTypeIdentityApiClient(PayamGostarApiClientConfig apiClientConfig, IPayamGostarApiProviderFactory apiProviderFactory) : base(apiClientConfig, apiProviderFactory)
        {
            _identityApiClient = apiProviderFactory.CreateCrmObjectTypeIdentityApiClient();
        }

        public async Task<ApiResponse<CrmObjectTypeResultDto>> CreateAsync(CrmObjectTypeIdentityCreationRequestDto request)
        {
            try
            {
                var identityCreationResult = await _identityApiClient.PostApiV2CrmobjecttypeIdentityCreateAsync(request.ToVM());

                return identityCreationResult.ConvertToApiResponse(result => result.ToDto());
            }
            catch (ApiException e)
            {
                throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(Helper.Helper.GetStringsFromProperties(request), e);
            }
        }

        public async Task<ApiResponse<IEnumerable<ProfileTypeGetResultDto>>> GetProfileTypeAsync()
        {
            try
            {
                var identityCreationResult = await _identityApiClient.PostApiV2CrmobjecttypeIdentityGetprofiletypeAsync();

                return identityCreationResult.ConvertToApiResponse(result => result.Select(x => x.ToDto()));
            }
            catch (ApiException e)
            {
                throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(e);
            }
        }
    }


}
