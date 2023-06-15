using PayamGostarClient.ApiProvider;
using PayamGostarClient.ApiServices.Dtos.PropertyGroupServiceDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayamGostarClient.ApiServices.Extension
{
    internal static class PropertyGroupServiceExtension
    {
        internal static CrmObjectPropertyGroupCreationResultDto ToDto(this CrmObjectPropertyGroupCreateResultVM vmResult)
        {
            return new CrmObjectPropertyGroupCreationResultDto
            {
                Id = vmResult.Id,
            };
        }

        internal static CrmObjectPropertyGroupCreateRequestVM ToVM(this CrmObjectPropertyGroupCreationRequestDto dto)
        {
            return new CrmObjectPropertyGroupCreateRequestVM
            {
                CountOfColumns = dto.CountOfColumns,
                CrmObjectTypeId = dto.CrmObjectTypeId,
                ExpandForView = dto.ExpandForView,
                Name = dto.Name.ToLocalizedResourceDto(),
            };
        }
    }
}
