using SeptaPay.PayamGostarClient.Initializer.Core.APIs;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.CrmObjectType;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeStageApiClientDtos;
using SeptaPay.PayamGostarClient.Initializer.Extension;
using SeptaPay.PayamGostarClient.RestApi;
using SeptaPay.PayamGostarClient.RestApi.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeptaPay.PayamGostarClient.Initializer.Models.Customization.CrmObjectType
{
    public class PayamGostarCrmObjectTypeStageApiClient : BaseApiClient, IPayamGostarCrmObjectTypeStageApiClient
    {
        private readonly ICrmObjectTypeStageApiClient _crmObjectTypeStageApiClient;

        public PayamGostarCrmObjectTypeStageApiClient(PayamGostarApiClientConfig apiClientConfig, IPayamGostarRestApiClientFactory apiProviderFactory) : base(apiClientConfig, apiProviderFactory)
        {
            _crmObjectTypeStageApiClient = ApiProviderFactory.CreateCrmObjectTypeStageApiClient();
        }

        public async Task<CrmObjectTypeStageCreationResultDto> CreateAsync(CrmObjectTypeStageCreationRequestDto request)
        {
            try
            {
                var stageCreationResult = await _crmObjectTypeStageApiClient.PostApiV2CrmobjecttypestageCreateAsync(request.ToVM());

                return stageCreationResult.Result.ToDto();
            }
            catch (ApiException e)
            {
                throw e.CreateApiServiceException(Core.Helper.Help.GetStringsFromProperties(request));
            }

        }

        public async Task<IEnumerable<StageGetResultDto>> GetStagesAsync(Guid crmObjectId)
        {
            var request = new CrmObjectTypeStageGetCollectionRequestVM
            {
                CrmObjectTypeId = crmObjectId,
            };

            try
            {
                var stageCreationResult = await _crmObjectTypeStageApiClient.PostApiV2CrmobjecttypestageGetcrmobjecttypestagesAsync(request);

                return stageCreationResult.Result.Select(x => x.ToDto());
            }
            catch (ApiException e)
            {
                throw e.CreateApiServiceException(Core.Helper.Help.GetStringsFromProperties(request));
            }

        }

    }
}
