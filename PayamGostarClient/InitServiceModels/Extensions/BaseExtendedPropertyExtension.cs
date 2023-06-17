using PayamGostarClient.ApiServices.Dtos;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeServiceDtos.Create;
using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.BaseStructure.Simple;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.ExtendedPropertyModels;
using System;
using System.Linq;

namespace PayamGostarClient.InitServiceModels.Extensions
{
    internal static class BaseExtendedPropertyExtension
    {
        public static T FillBaseExtendedPropertyDto<T>(this T target, BaseExtendedPropertyModel from)
            where T : BaseExtendedPropertyCreationDto
        {
            if (string.IsNullOrEmpty(from.CrmObjectTypeId))
            {
                throw new ExtendedPropertyCreationDtoException("CrmObjectTypeId can not be null.");
            }

            target.UserKey = from.UserKey;
            target.PropertyGroupId = from.PropertyGroup.Id;
            target.Name = new SystemResourceValueDto { ResourceValues = from.Name.Select(r => r.ToDto()) };
            target.ToolTip = new SystemResourceValueDto { ResourceValues = from.ToolTip.Select(r => r.ToDto()) };
            target.CrmObjectTypeId = Guid.Parse(from.CrmObjectTypeId);

            return target;
        }

        public static T FillBaseExtendedPropertyModel<T>(this T target, ExtendedPropertyGetResultDto from)
            where T : BaseExtendedPropertyModel
        {
            target.UserKey = from.UserKey;
            target.Name = BaseInitServiceExtension.ToResourceValues(from.Name);
            target.ToolTip = BaseInitServiceExtension.ToResourceValues(from.Tooltip);
            target.CrmObjectTypeId = from.CrmObjectTypeId.ToString();
            target.DefaultValue = from.DefaultValue;
            target.IsRequired = from.IsRequired;

            return target;
        }

        public static ResourceValueDto ToDto(this ResourceValue resourceValue)
        {
            return new ResourceValueDto { Value = resourceValue.Value, LanguageCulture = resourceValue.LanguageCulture };
        }


    }
}
