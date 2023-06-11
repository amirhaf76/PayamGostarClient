using PayamGostarClient.ApiServices.Dtos;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.CrmObjectTypeModels;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.ExtendedPropertyModels;
using System.Linq;

namespace PayamGostarClient.ApiServices.Extension
{
    public static class BaseApiServiceExtension
    {

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
    }
}
