using PayamGostarClient.ApiClient.Abstractions.Customization.CrmObjectType;
using PayamGostarClient.ApiClient.ApiProvider.Abstractions;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeStageApiClientDtos;
using PayamGostarClient.ApiClient.Extension;
using PayamGostarClient.ApiProvider;
using PayamGostarClient.Helper.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiClient.Models.Customization.CrmObjectType
{
    public class PayamGostarCrmObjectTypeStageApiClient : BaseApiClient, IPayamGostarCrmObjectTypeStageApiClient
    {
        private readonly ICrmObjectTypeStageApiClient _crmObjectTypeStageApiClient;

        public PayamGostarCrmObjectTypeStageApiClient(PayamGostarApiClientConfig apiClientConfig, IPayamGostarApiProviderFactory apiProviderFactory) : base(apiClientConfig, apiProviderFactory)
        {
            _crmObjectTypeStageApiClient = ApiProviderFactory.CreateCrmObjectTypeStageApiClient();
        }

        public async Task<ApiResponse<CrmObjectTypeStageCreationResultDto>> CreateAsync(CrmObjectTypeStageCreationRequestDto request)
        {
            try
            {
                var stageCreationResult = await _crmObjectTypeStageApiClient.PostApiV2CrmobjecttypestageCreateAsync(request.ToVM());

                return stageCreationResult.ConvertToApiResponse(result => result.ToDto());
            }
            catch (ApiException e)
            {
                throw e.CreateApiServiceException(Helper.Helper.GetStringsFromProperties(request));
            }

        }

        public async Task<ApiResponse<IEnumerable<StageGetResultDto>>> GetStagesAsync(Guid crmObjectId)
        {
            var request = new CrmObjectTypeStageGetCollectionRequestVM
            {
                CrmObjectTypeId = crmObjectId,
            };

            try
            {
                var stageCreationResult = await _crmObjectTypeStageApiClient.PostApiV2CrmobjecttypestageGetcrmobjecttypestagesAsync(request);

                return stageCreationResult.ConvertToApiResponse(result => result.Select(x => x.ToDto()));
            }
            catch (ApiException e)
            {
                throw e.CreateApiServiceException(Helper.Helper.GetStringsFromProperties(request));
            }

        }

    }
}
