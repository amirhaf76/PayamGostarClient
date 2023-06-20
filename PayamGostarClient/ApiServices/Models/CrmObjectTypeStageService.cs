using PayamGostarClient.ApiProvider;
using PayamGostarClient.ApiProvider.Abstractions;
using PayamGostarClient.ApiServices.Abstractions;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeStageServiceDtos;
using PayamGostarClient.ApiServices.Extension;
using PayamGostarClient.Helper.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiServices.Models
{
    public class CrmObjectTypeStageService : BaseApiService, ICrmObjectTypeStageService
    {
        private readonly ICrmObjectTypeStageApiClient _crmObjectTypeStageApiClient;

        public CrmObjectTypeStageService(PayamGostarClientConfig clientConfig, IPayamGostarClientAbstractFactory clientFactory) : base(clientConfig, clientFactory)
        {
            _crmObjectTypeStageApiClient = ClientFactory.CreateCrmObjectTypeStageApiClient();
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
                throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(Helper.Helper.GetStringsFromProperties(request), e);
            }

        }

        public async Task<ApiResponse<IEnumerable<CrmObjectTypeStageGetResultDto>>> GetStagesAsync(Guid crmObjectId)
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
                throw ApiResponseExtension.CreateApiExceptionDtoFromApiException(Helper.Helper.GetStringsFromProperties(request), e);
            }

        }

    }
}
