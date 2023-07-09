using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeStageApiClientDtos;
using PayamGostarClient.Helper.Net;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiClient.Abstractions.Customization.CrmObjectType
{
    public interface IPayamGostarCrmObjectTypeStageApiClient
    {
        Task<ApiResponse<CrmObjectTypeStageCreationResultDto>> CreateAsync(CrmObjectTypeStageCreationRequestDto request);

        Task<ApiResponse<IEnumerable<StageGetResultDto>>> GetStagesAsync(Guid crmObjectId);
    }
}