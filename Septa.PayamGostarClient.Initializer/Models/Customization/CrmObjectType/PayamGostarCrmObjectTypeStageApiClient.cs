using Septa.PayamGostarClient.Initializer.Core.APIs;
using Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.CrmObjectType;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeStageApiClientDtos;
using Septa.PayamGostarClient.Initializer.Core.Helper;
using Septa.PayamGostarClient.Initializer.Extension;
using Septa.PayamGostarClient.RestApi;
using Septa.PayamGostarClient.RestApi.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Septa.PayamGostarClient.Initializer.Models.Customization.CrmObjectType
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
                throw e.CreateApiServiceException(Help.GetStringsFromProperties(request));
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
                throw e.CreateApiServiceException(Help.GetStringsFromProperties(request));
            }

        }

    }
}
