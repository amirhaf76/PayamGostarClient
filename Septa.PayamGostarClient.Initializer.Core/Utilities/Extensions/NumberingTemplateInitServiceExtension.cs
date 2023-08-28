using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.NumberingTemplateDtos.Create;
using Septa.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeGeneralModels;

namespace Septa.PayamGostarClient.Initializer.Core.Utilities.Extensions
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
