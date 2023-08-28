using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeIdentityApiClientDtos.Create;
using Septa.PayamGostarClient.Initializer.Core.APIs.Enums;
using Septa.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeModels;
using System;

namespace Septa.PayamGostarClient.Initializer.Core.Utilities.Extensions
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
