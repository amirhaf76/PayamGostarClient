using Septa.PayamGostarClient.Initializer.Core.APIs;
using Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.CrmObjectType;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeIdentityApiClientDtos.Create;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeIdentityApiClientDtos.Get;
using Septa.PayamGostarClient.Initializer.Core.Helper;
using Septa.PayamGostarClient.Initializer.Extension;
using Septa.PayamGostarClient.RestApi;
using Septa.PayamGostarClient.RestApi.Factory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Septa.PayamGostarClient.Initializer.Models.Customization.CrmObjectType
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
                throw e.CreateApiServiceException(Help.GetStringsFromProperties(request));
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
