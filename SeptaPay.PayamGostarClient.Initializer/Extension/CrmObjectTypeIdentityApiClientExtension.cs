using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeIdentityApiClientDtos.Create;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeIdentityApiClientDtos.Get;
using SeptaPay.PayamGostarClient.RestApi;

namespace SeptaPay.PayamGostarClient.Initializer.Extension
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
