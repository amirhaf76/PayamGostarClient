using Septa.PayamGostarClient.Initializer.Core.APIs;
using Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.PropertyGroup;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.PropertyGroupApiClientDtos;
using Septa.PayamGostarClient.Initializer.Core.Helper;
using Septa.PayamGostarClient.Initializer.Extension;
using Septa.PayamGostarClient.RestApi;
using Septa.PayamGostarClient.RestApi.Factory;
using System.Threading.Tasks;

namespace Septa.PayamGostarClient.Initializer.Models.Customization.PropertyGroup
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
                throw e.CreateApiServiceException(Help.GetStringsFromProperties(request));
            }

        }
    }
}
