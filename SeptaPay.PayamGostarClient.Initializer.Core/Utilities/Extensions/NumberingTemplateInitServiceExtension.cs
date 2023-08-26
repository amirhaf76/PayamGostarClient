using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.NumberingTemplateDtos.Create;
using SeptaPay.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeGeneralModels;

namespace SeptaPay.PayamGostarClient.Initializer.Core.Utilities.Extensions
{
    internal static class NumberingTemplateInitServiceExtension
    {
        internal static NumberingTemplateCreationRequestDto ToDto(this NumberingTemplateModel model)
        {
            return new NumberingTemplateCreationRequestDto
            {
                Name = model.Name,
                Prefix = model.Prefix,
                InitialSeed = model.InitialSeed,
                LastNumber = model.LastNumber,
                ResetNumberInNewPrefix = model.ResetNumberInNewPrefix,
            };
        }

    }
}
