using PayamGostarClient.ApiClient.Dtos.CrmObjectTypeIdentityApiClientDtos.Create;
using PayamGostarClient.ApiProvider;

namespace PayamGostarClient.ApiClient.Extension
{
    public static class CrmObjectTypeIdentitApiClientExtension
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
    }
}
