using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeStageApiClientDtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.CrmObjectType
{
    public interface IPayamGostarCrmObjectTypeStageApiClient
    {
        Task<CrmObjectTypeStageCreationResultDto> CreateAsync(CrmObjectTypeStageCreationRequestDto request);

        Task<IEnumerable<StageGetResultDto>> GetStagesAsync(Guid crmObjectId);


        CrmObjectTypeStageCreationResultDto Create(CrmObjectTypeStageCreationRequestDto request);

        IEnumerable<StageGetResultDto> GetStages(Guid crmObjectId);
    }
}