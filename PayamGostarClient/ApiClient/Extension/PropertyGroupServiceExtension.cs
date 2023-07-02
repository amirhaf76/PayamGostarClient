using PayamGostarClient.ApiProvider;
using System;
using System.Collections.Generic;
using System.Text;
using PayamGostarClient.ApiClient.Dtos.PropertyGroupApiClientDtos;

namespace PayamGostarClient.ApiClient.Extension
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
