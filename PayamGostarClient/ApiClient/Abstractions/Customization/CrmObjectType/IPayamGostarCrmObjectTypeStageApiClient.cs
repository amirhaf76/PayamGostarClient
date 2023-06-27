using PayamGostarClient.ApiClient.Dtos.CrmObjectTypeStageServiceDtos;
using PayamGostarClient.Helper.Net;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiClient.Abstractions
{
    public interface IPayamGostarCrmObjectTypeStageApiClient
    {
        Task<ApiResponse<CrmObjectTypeStageCreationResultDto>> CreateAsync(CrmObjectTypeStageCreationRequestDto request);

        Task<ApiResponse<IEnumerable<CrmObjectTypeStageGetResultDto>>> GetStagesAsync(Guid crmObjectId);
    }
}