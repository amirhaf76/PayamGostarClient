using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.PropertyGroupApiClientDtos;
using Septa.PayamGostarClient.RestApi;

namespace Septa.PayamGostarClient.Initializer.Extension
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
