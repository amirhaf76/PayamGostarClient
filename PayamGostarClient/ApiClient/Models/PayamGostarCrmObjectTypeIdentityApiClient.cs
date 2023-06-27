using PayamGostarClient.ApiProvider;
using PayamGostarClient.ApiProvider.Abstractions;
using PayamGostarClient.ApiClient.Abstractions;
using PayamGostarClient.ApiClient.Dtos.CrmObjectTypeServiceDtos;
using PayamGostarClient.ApiClient.Extension;
using PayamGostarClient.Helper.Net;
using System.Threading.Tasks;
using PayamGostarClient.ApiClient.Dtos.CrmObjectTypeIdentityApiClientDtos.Create;

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
                var ticketCreationResult = await _identityApiClient.PostApiV2CrmobjecttypeIdentityCreateAsync(request.ToVM());

                return ticketCreationResult.ConvertToApiResponse(result => result.ToDto());
            }
            catch (ApiException e)
            {
                throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(Helper.Helper.GetStringsFromProperties(request), e);
            }
        }
    }


}
