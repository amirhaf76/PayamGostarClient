using PayamGostarClient.ApiProvider;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeStageServiceDtos;

namespace PayamGostarClient.ApiServices.Extension
{
    internal static class CrmObjectTypeStageServiceExtension
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
         
        internal static CrmObjectTypeStageGetResultDto ToDto(this CrmObjectTypeStageGetResultVM vm)
        {
            return new CrmObjectTypeStageGetResultDto
            {
                Id = vm.Id,
                CrmObjectTypeId = vm.CrmObjectTypeId,
                Name = vm.Name,
                NameResourceKey = vm.NameResourceKey,
                Key = vm.Key,
                Index = vm.Index,
                IsDoneStage = vm.IsDoneStage,
                IsActive = vm.IsActive,

            };
        }
    }
}
