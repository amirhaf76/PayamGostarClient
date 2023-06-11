using PayamGostarClient.ApiProvider;
using PayamGostarClient.ApiServices.Dtos;
using PayamGostarClient.Models;
using System.Linq;

namespace PayamGostarClient.ApiServices.Extension
{
    public static class CrmObjectTypeApiServiceExtension
    {
        private const string DEFAULT_LANGUAGE_CULTURE = "Fa";

        public static BaseCrmModelDto ConvertToBaseCrmModelDto(this BaseCRMModel crmModel)
        {
            return new BaseCrmModelDto
            {
                Type = (int)crmModel.Type,
                Code = crmModel.Code,
                Name = crmModel.Name.Select(n => n.ConvertToResourceValue()),
                Description = crmModel.Description.Select(d => d.ConvertToResourceValue()),
                Properties = crmModel.Properties.Select(p => p.ConvertToBaseExtendedPropertyModelDto()),
                PropertyGroups = crmModel.PropertyGroups.Select(pg => pg.ConvertToPropertyGroupDto()),
                Stages = crmModel.Stages.Select(s => s.ConvertToStageDto()),
            };
        }

        public static CrmObjectTypeSearchRequestVM ConvertToCrmObjectTypeSearchRequestVM(this BaseCRMModel crmModel, string languageCulture = DEFAULT_LANGUAGE_CULTURE, int pageSiz = 10, int pageNumber = 1)
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

        public static ResourceValueDto ConvertToResourceValue(this ResourceValue resourceValue)
        {
            return new ResourceValueDto { Value = resourceValue.Value, LanguageCulture = resourceValue.LanguageCulture };
        }

        public static BaseExtendedPropertyModelDto ConvertToBaseExtendedPropertyModelDto(this BaseExtendedPropertyModel property)
        {
            return new BaseExtendedPropertyModelDto
            {
                Name = property.Name.Select(n => n.ConvertToResourceValue()),
                ToolTip = property.ToolTip.Select(tp => tp.ConvertToResourceValue()),
                UserKey = property.UserKey
            };
        }

        public static PropertyGroupDto ConvertToPropertyGroupDto(this PropertyGroup propertyGroup)
        {
            return new PropertyGroupDto
            {
                Name = propertyGroup.Name.Select(n => n.ConvertToResourceValue()),
                CountOfColumns = propertyGroup.CountOfColumns,
                Expanded = propertyGroup.Expanded,
            };
        }

        public static StageDto ConvertToStageDto(this Stage stage)
        {
            return new StageDto
            {
                Name = stage.Name.Select(n => n.ConvertToResourceValue()),
                Enabled = stage.Enabled,
                IsDoneStage = stage.IsDoneStage,
                Key = stage.Key,
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
