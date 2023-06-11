using PayamGostarClient.ApiProvider;
using PayamGostarClient.ApiServices.Dtos;
using System.Linq;

namespace PayamGostarClient.ApiServices.Extension
{
    public static class CrmObjectTypeApiServiceExtension
    {
        private const string DEFAULT_LANGUAGE_CULTURE = "Fa";

        public static CrmObjectTypeSearchRequestVM ConvertToCrmObjectTypeSearchRequestVM(this BaseCrmModelDto crmModel, string languageCulture = DEFAULT_LANGUAGE_CULTURE, int pageSiz = 10, int pageNumber = 1)
        {
            return new CrmObjectTypeSearchRequestVM
            {
                Code = crmModel.Code,
                CrmObjectTypeIndex = (int?)crmModel.Type,
                PageNumber = pageNumber,
                PageSize = pageSiz,
                Name = crmModel.Name
                    .Where(x => x.LanguageCulture == languageCulture)
                    .FirstOrDefault()
                    .Value,
            };
        }
        public static CrmObjectTypeGetResultDto ConvertToCrmObjectTypeGetResultDto(this CrmObjectTypeGetResultVM viewModel)
        {
            return new CrmObjectTypeGetResultDto
            {
                Code = viewModel.Code,
                Name = viewModel.Name,
                CrmOjectTypeIndex = viewModel.CrmOjectTypeIndex,
                Description = viewModel.Description,
                Properties = viewModel.Properties.Select(property => new PropertyDefinitionGetResultDto
                {
                    UserKey = property.UserKey,
                    Name = property.Name,
                    NameResourceKey = property.NameResourceKey,
                    Tooltip = property.Tooltip,
                    TooltipResourceKey = property.TooltipResourceKey,
                    CrmObjectTypeId = property.CrmObjectTypeId,
                }),
                Groups = viewModel.Groups.Select(group => new CrmObjectPropertyGroupGetResultDto
                {
                    CrmObjectTypeId = group.CrmObjectTypeId,
                    Name = group.Name,
                    NameResourceKey = group.NameResourceKey,
                    CountOfColumns = group.CountOfColumns,
                    ExpandForView = group.ExpandForView,
                }),
                Stages = viewModel.Stages.Select(stage => new CrmObjectTypeStageGetResultDto
                {
                    CrmObjectTypeId = stage.CrmObjectTypeId,
                    Name = stage.Name,
                    NameResourceKey = stage.NameResourceKey,
                    Key = stage.Key,
                    IsDoneStage = stage.IsDoneStage,
                    IsActive = stage.IsActive,
                }),
            };
        }

    }
}
