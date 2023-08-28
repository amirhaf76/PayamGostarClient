using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeIdentityApiClientDtos.Create;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeIdentityApiClientDtos.Get;
using Septa.PayamGostarClient.RestApi;

namespace Septa.PayamGostarClient.Initializer.Extension
{
    public static class CrmObjectTypeIdentityApiClientExtension
    {
        public static CrmObjectTypeIdentityCreateRequestVM ToVM(this CrmObjectTypeIdentityCreationRequestDto dto)
        {
            return new CrmObjectTypeIdentityCreateRequestVM
            {
                NumberingTemplateId = dto.NumberingTemplateId,
                IdentityTypeIndex = dto.IdentityTypeIndex,
                IdentityFunctionIndex = dto.IdentityFunctionIndex,
                ProfileTypeId = dto.ProfileTypeId,

            }.FillBaseCrmObjectTypeCreateRequestVM(dto);
        }

        public static ProfileTypeGetResultDto ToDto(this ProfileTypeGetResultVM vm)
        {
            return new ProfileTypeGetResultDto
            {
                Id = vm.Id,
                ProfileTypeIndex = vm.ProfileTypeIndex,
                ProfileTypeName = vm.ProfileTypeName,
                CanAccessToPortal = vm.CanAccessToPortal,
                PointCalendarTypeIndex = vm.PointCalendarTypeIndex,
                PointExpireTypeIndex = vm.PointExpireTypeIndex,
                PointExpireValue = vm.PointExpireValue,
                PointReturnValue = vm.PointReturnValue,

            };
        }
    }
}
