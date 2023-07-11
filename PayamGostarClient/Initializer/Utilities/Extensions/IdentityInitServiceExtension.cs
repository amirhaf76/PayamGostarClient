using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeIdentityApiClientDtos.Create;
using PayamGostarClient.ApiClient.Enums;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;
using System;

namespace PayamGostarClient.Initializer.Utilities.Extensions
{
    internal static class IdentityInitServiceExtension
    {
        public static CrmObjectTypeIdentityCreationRequestDto ToDtoBy(this CrmIdentityModel model, Func<Gp_ProfileType, Guid> getProfileTypeId)
        {
            return new CrmObjectTypeIdentityCreationRequestDto
            {
                NumberingTemplateId = model.NumberingTemplate?.Id ?? default,
                IdentityTypeIndex = (int)model.IdentityTypeIndex,
                IdentityFunctionIndex = (int)model.IdentityFunctionIndex,
                ProfileTypeId = getProfileTypeId(model.ProfileType),

            }.FillBaseCrmObjectTypeCreateRequestDto(model);
        }
    }
}
