using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeIdentityApiClientDtos.Create;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Enums;
using SeptaPay.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeModels;
using System;

namespace SeptaPay.PayamGostarClient.Initializer.Core.Utilities.Extensions
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
