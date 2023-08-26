using SeptaPay.PayamGostarClient.Initializer.Core.APIs;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.PropertyGroup;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.PropertyGroupApiClientDtos;
using SeptaPay.PayamGostarClient.Initializer.Extension;
using SeptaPay.PayamGostarClient.RestApi;
using SeptaPay.PayamGostarClient.RestApi.Factory;
using System.Threading.Tasks;

namespace SeptaPay.PayamGostarClient.Initializer.Models.Customization.PropertyGroup
{
    public class PayamGostarPropertyGroupApiClient : BaseApiClient, IPayamGostarPropertyGroupApiClient
    {
        private readonly IPropertyGroupApiClient _propertyGroupApiClient;

        public PayamGostarPropertyGroupApiClient(PayamGostarApiClientConfig apiClientConfig, IPayamGostarRestApiClientFactory apiProviderFactory) : base(apiClientConfig, apiProviderFactory)
        {
            _propertyGroupApiClient = ApiProviderFactory.CreatePropertyGroupApiClient();

        }

        public async Task<CrmObjectPropertyGroupCreationResultDto> CreateAsync(CrmObjectPropertyGroupCreationRequestDto request)
        {
            try
            {
                var groupCreationResult = await _propertyGroupApiClient.PostApiV2CrmobjecttypepropertygroupCreateAsync(request.ToVM());

                return groupCreationResult.Result.ToDto();
            }
            catch (ApiException e)
            {
                throw e.CreateApiServiceException(Core.Helper.Help.GetStringsFromProperties(request));
            }

        }
    }
}
