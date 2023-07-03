using PayamGostarClient.ApiClient.Dtos.NumberingTemplateDtos.Create;
using PayamGostarClient.ApiClient.Dtos.NumberingTemplateDtos.Search;
using PayamGostarClient.ApiProvider;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayamGostarClient.ApiClient.Extension
{
    internal static class NumberingTemplateApiClientExtension
    {
        internal static NumberingTemplateCreationRequestVM ToVM(this NumberingTemplateCreationRequestDto dto)
        {
            return new NumberingTemplateCreationRequestVM
            {
                Name = dto.Name,
                Prefix = dto.Prefix,
                InitialSeed = dto.InitialSeed,
                LastNumber = dto.LastNumber,
                ResetNumberInNewPrefix = dto.ResetNumberInNewPrefix,
            };
        }

        internal static NumberingTemplateCreationResultDto ToDto(this NumberingTemplateCreationResultVM vm)
        {
            return new NumberingTemplateCreationResultDto
            {
                NumberingTemplateId = vm.NumberingTemplateId,
                Name = vm.Name,
                Prefix = vm.Prefix,
                InitialSeed = vm.InitialSeed,
                LastNumber = vm.LastNumber,
                ResetNumberInNewPrefix = vm.ResetNumberInNewPrefix,
                TemplatedIsUsed = vm.TemplatedIsUsed,
            };
        }

        internal static NumberingTemplateSearchResultDto ToDto(this NumberingTemplateSearchResultVM vm)
        {
            return new NumberingTemplateSearchResultDto
            {
                Id = vm.Id,
                Name = vm.Name,
                Prefix = vm.Prefix,
                InitialSeed = vm.InitialSeed,
                LastNumber = vm.LastNumber,
                LastPrefix = vm.LastPrefix,

            };
        }

        internal static NumberingTemplateSearchRequestVM ToVM(this NumberingTemplateSearchRequestDto dto)
        {
            return new NumberingTemplateSearchRequestVM
            {
                Id = dto.Id,
                Name = dto.Name,
                Prefix = dto.Prefix,
                InitialSeed = dto.InitialSeed,
                LastNumber = dto.LastNumber,
                LastPrefix = dto.LastPrefix,

            };
        }
    }
}
