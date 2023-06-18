using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeStageServiceDtos;
using PayamGostarClient.Helper.Net;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiServices.Abstractions
{
    public interface ICrmObjectTypeStageService
    {
        Task<ApiResponse<CrmObjectTypeStageCreationResultDto>> CreateAsync(CrmObjectTypeStageCreationRequestDto request);

        Task<ApiResponse<IEnumerable<CrmObjectTypeStageGetResultDto>>> GetStagesAsync(Guid crmObjectId);
    }
}