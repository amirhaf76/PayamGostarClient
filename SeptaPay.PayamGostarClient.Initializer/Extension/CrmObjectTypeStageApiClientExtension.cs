using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeStageApiClientDtos;
using SeptaPay.PayamGostarClient.RestApi;

namespace SeptaPay.PayamGostarClient.Initializer.Extension
{
    internal static class CrmObjectTypeStageApiClientExtension
    {
        internal static CrmObjectTypeStageCreateRequestVM ToVM(this CrmObjectTypeStageCreationRequestDto dto)
        {
            return new CrmObjectTypeStageCreateRequestVM
            {
                CrmObjectTypeId = dto.CrmObjectTypeId,
                IsActive = dto.Enabled,
                Index = dto.Index,
                IsDoneStage = dto.IsDoneStage,
                Key = dto.Key,
                Name = dto.Name.ToSystemResourceValueVM(),
            };
        }

        internal static CrmObjectTypeStageCreationResultDto ToDto(this CrmObjectTypeStagePostResultVM vmResult)
        {
            return new CrmObjectTypeStageCreationResultDto
            {
                StageId = vmResult.StageId,
            };
        }
    }
}
