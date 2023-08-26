using SeptaPay.PayamGostarClient.Initializer.Core.APIs;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.CrmObjectType;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeIdentityApiClientDtos.Create;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeIdentityApiClientDtos.Get;
using SeptaPay.PayamGostarClient.Initializer.Extension;
using SeptaPay.PayamGostarClient.RestApi;
using SeptaPay.PayamGostarClient.RestApi.Factory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeptaPay.PayamGostarClient.Initializer.Models.Customization.CrmObjectType
{
    internal class PayamGostarCrmObjectTypeIdentityApiClient : BaseApiClient, IPayamGostarCrmObjectTypeIdentityApiClient
    {
        private readonly ICrmObjectTypeIdentityApiClient _identityApiClient;

        public PayamGostarCrmObjectTypeIdentityApiClient(PayamGostarApiClientConfig apiClientConfig, IPayamGostarRestApiClientFactory apiProviderFactory) : base(apiClientConfig, apiProviderFactory)
        {
            _identityApiClient = apiProviderFactory.CreateCrmObjectTypeIdentityApiClient();
        }

        public async Task<CrmObjectTypeResultDto> CreateAsync(CrmObjectTypeIdentityCreationRequestDto request)
        {
            try
            {
                var identityCreationResult = await _identityApiClient.PostApiV2CrmobjecttypeIdentityCreateAsync(request.ToVM());

                return identityCreationResult.Result.ToDto();
            }
            catch (ApiException e)
            {
                throw e.CreateApiServiceException(Core.Helper.Help.GetStringsFromProperties(request));
            }
        }

        public async Task<IEnumerable<ProfileTypeGetResultDto>> GetProfileTypeAsync()
        {
            try
            {
                var identityCreationResult = await _identityApiClient.PostApiV2CrmobjecttypeIdentityGetprofiletypeAsync();

                return identityCreationResult.Result.Select(x => x.ToDto());
            }
            catch (ApiException e)
            {
                throw e.CreateApiServiceException();
            }
        }
    }


}
