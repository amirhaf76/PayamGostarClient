using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos;
using PayamGostarClient.ApiClient.Dtos.ExtendedPropertyApiClientDtos.BaseStructure.Simple;
using PayamGostarClient.Initializer.CrmModels;
using PayamGostarClient.Initializer.CrmModels.ExtendedPropertyModels;
using PayamGostarClient.Initializer.Exceptions;
using System;
using System.Linq;

namespace PayamGostarClient.Initializer.Extensions
{
    internal static class BaseExtendedPropertyExtension
    {
        public static T FillBaseExtendedPropertyDto<T>(this T target, BaseExtendedPropertyModel from)
            where T : BaseExtendedPropertyCreationDto
        {
            if (!Guid.TryParse(from.CrmObjectTypeId, out Guid crmObjectTypeId))
            {
                throw new ExtendedPropertyCreationDtoException($"Parsing crmObjectTypeId was unsuccessful! Userkey: {from.UserKey} CrmObjectTypeId: {from.CrmObjectTypeId}");
            }

            target.UserKey = from.UserKey;
            target.PropertyGroupId = from.PropertyGroup.Id;
            target.Name = new SystemResourceValueDto { ResourceValues = from.Name?.Select(r => r.ToDto()) ?? Array.Empty<ResourceValueDto>() };
            target.ToolTip = new SystemResourceValueDto { ResourceValues = from.ToolTip?.Select(r => r.ToDto()) ?? Array.Empty<ResourceValueDto>() };
            target.CrmObjectTypeId = crmObjectTypeId;
            target.DefaultValue = from.DefaultValue;

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
            target.DefaultValue = from.DefaultValue;

            return target;
        }

        public static ResourceValueDto ToDto(this ResourceValue resourceValue)
        {
            return new ResourceValueDto { Value = resourceValue.Value, LanguageCulture = resourceValue.LanguageCulture };
        }


    }
}
