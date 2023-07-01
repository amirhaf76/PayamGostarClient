using PayamGostarClient.ApiClient.Dtos.CrmObjectTypeIdentityApiClientDtos.Create;
using PayamGostarClient.ApiClient.Enums;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;
using System;

namespace PayamGostarClient.Initializer.Extensions
{
    internal static class IdentityInitServiceExtension
    {
        public static CrmObjectTypeIdentityCreationRequestDto ToDtoBy(this CrmIdentityModel model, Func<Gp_ProfileType, Guid> getProfileTypeId)
        {
            return new CrmObjectTypeIdentityCreationRequestDto
            {
                NumberingTemplateId = model.NumberingTemplateId,
                IdentityTypeIndex = model.IdentityTypeIndex,
                IdentityFunctionIndex = model.IdentityFunctionIndex,
                ProfileTypeId = getProfileTypeId(model.ProfileType),

            }.FillBaseCrmObjectTypeCreateRequestDto(model);
        }
    }
}
