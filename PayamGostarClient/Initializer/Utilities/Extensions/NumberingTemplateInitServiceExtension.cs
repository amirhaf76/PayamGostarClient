﻿using PayamGostarClient.ApiClient.Dtos.CategoryDtos.Search;
using PayamGostarClient.ApiClient.Dtos.NumberingTemplateDtos.Create;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeGeneralModels;

namespace PayamGostarClient.Initializer.Utilities.Extensions
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
