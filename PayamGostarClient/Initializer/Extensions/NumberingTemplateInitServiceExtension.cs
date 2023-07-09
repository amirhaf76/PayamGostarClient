using PayamGostarClient.ApiClient.Dtos.NumberingTemplateDtos.Create;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeGeneralModels;

namespace PayamGostarClient.Initializer.Extensions
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
