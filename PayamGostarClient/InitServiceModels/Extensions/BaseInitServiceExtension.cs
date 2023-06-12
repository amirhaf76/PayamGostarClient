using PayamGostarClient.ApiServices.Dtos;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.ExtendedPropertyModels;
using PayamGostarClient.InitServiceModels.Models;
using System.Linq;

namespace PayamGostarClient.InitServiceModels.Extensions
{
    internal static class BaseInitServiceExtension
    {

        internal static SearchedCrmObjectModel ConvertToSearchedCrmObjectModel(this CrmObjectTypeSearchResultDto crmModel)
        {
            var crmObjectType = (Gp_CrmObjectType)crmModel.CrmOjectTypeIndex;

            return new SearchedCrmObjectModel(crmObjectType)
            {
                Code = crmModel.Code,
                Name = ConvertToResourceValues(crmModel.Name),
                Description = ConvertToResourceValues(crmModel.Description),
                Properties = crmModel.Properties?.Select(p => p.To()).ToList(),
                PropertyGroups = crmModel.Groups?.Select(g => g.To()).ToList(),
                Stages = crmModel.Stages?.Select(p => p.To()).ToList(),
            };
        }

        // Todo: Warning! using hard code value for Language Culture.
        internal static ResourceValue[] ConvertToResourceValues(string value)
        {
            return new ResourceValue[] { new ResourceValue { Value = value, LanguageCulture = "Fa" } };
        }

        internal static PropertyGroup To(this PropertyGroupGetResultDto group)
        {
            return new PropertyGroup
            {
                Name = ConvertToResourceValues(group.Name),
                Expanded = group.ExpandForView,
                CountOfColumns = group.CountOfColumns ?? 0,
            };
        }

        internal static BaseExtendedPropertyModel To(this ExtendedPropertyGetResultDto property)
        {
            return new SearchedExtendedPropertyModel
            {
                UserKey = property.UserKey,
                Name = ConvertToResourceValues(property.Name),
                ToolTip = ConvertToResourceValues(property.Tooltip),
                PropertyGroup = To(property.Group),
            };
        }

        internal static Stage To(this StageGetResultDto stage)
        {
            return new Stage
            {
                Name = ConvertToResourceValues(stage.Name),
                Enabled = stage.IsActive,
                IsDoneStage = stage.IsDoneStage,
                Key = stage.Key,
            };
        }

    }
}
