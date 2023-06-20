using PayamGostarClient.ApiProvider;
using PayamGostarClient.ApiProvider.Abstractions;
using PayamGostarClient.ApiServices.Abstractions;
using PayamGostarClient.ApiServices.Dtos.PropertyGroupServiceDtos;
using PayamGostarClient.ApiServices.Extension;
using PayamGostarClient.Helper.Net;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiServices.Models
{
    public class PropertyGroupService : BaseApiService, IPropertyGroupService
    {
        private readonly IPropertyGroupApiClient _propertyGroupApiClient;

        public PropertyGroupService(PayamGostarClientConfig clientConfig, IPayamGostarClientAbstractFactory clientFactory) : base(clientConfig, clientFactory)
        {
            _propertyGroupApiClient = ClientFactory.CreatePropertyGroupApiClient();
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
