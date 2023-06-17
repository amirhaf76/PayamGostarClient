﻿using PayamGostarClient.ApiProvider;
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