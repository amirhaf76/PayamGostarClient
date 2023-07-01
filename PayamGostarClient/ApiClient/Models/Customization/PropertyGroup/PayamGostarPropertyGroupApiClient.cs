using PayamGostarClient.ApiProvider;
using PayamGostarClient.ApiClient.Extension;
using PayamGostarClient.Helper.Net;
using System.Threading.Tasks;
using PayamGostarClient.ApiClient.Abstractions.Customization.PropertyGroup;
using PayamGostarClient.ApiClient.Dtos.PropertyGroupApiClientDtos;
using PayamGostarClient.ApiClient.ApiProvider.Abstractions;

namespace PayamGostarClient.ApiClient.Models.Customization.PropertyGroup
{
    public class PayamGostarPropertyGroupApiClient : BaseApiClient, IPayamGostarPropertyGroupApiClient
    {
        private readonly IPropertyGroupApiClient _propertyGroupApiClient;

        public PayamGostarPropertyGroupApiClient(PayamGostarApiClientConfig apiClientConfig, IPayamGostarApiProviderFactory apiProviderFactory) : base(apiClientConfig, apiProviderFactory)
        {
            _propertyGroupApiClient = ApiProviderFactory.CreatePropertyGroupApiClient();

        }

        public async Task<ApiResponse<CrmObjectPropertyGroupCreationResultDto>> CreateAsync(CrmObjectPropertyGroupCreationRequestDto request)
        {
            try
            {
                var groupCreationResult = await _propertyGroupApiClient.PostApiV2CrmobjecttypepropertygroupCreateAsync(request.ToVM());

                return groupCreationResult.ConvertToApiResponse(result => result.ToDto());
            }
            catch (ApiException e)
            {
                throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(Helper.Helper.GetStringsFromProperties(request), e);
            }

        }
    }
}
