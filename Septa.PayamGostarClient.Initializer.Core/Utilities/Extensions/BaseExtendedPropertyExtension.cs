using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.ExtendedPropertyApiClientDtos.BaseStructure.Simple;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.ExtendedPropertyApiClientDtos.SimpleExtendedProperies;
using Septa.PayamGostarClient.Initializer.Core.CrmModels;
using Septa.PayamGostarClient.Initializer.Core.CrmModels.ExtendedPropertyModels;
using Septa.PayamGostarClient.Initializer.Core.Exceptions;
using System;
using System.Linq;

namespace Septa.PayamGostarClient.Initializer.Core.Utilities.Extensions
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

        public static T FillCrmItemExtendedPropertyCreationDto<T>(this T target, BaseExtendedPropertyModel from)
            where T : CrmItemExtendedPropertyCreationDto
        {
            var crmObjectModel = (CrmObjectExtendedPropertyModel)from;

            target.PreventSettingContainerCrmobjectAsParent = crmObjectModel.PreventSettingContainerCrmobjectAsParent;
            target.ReferencedItemCrmObjectTypeId = crmObjectModel.ReferencedItemCrmObjectTypeId;

            return target.FillBaseExtendedPropertyDto(from);
        }

        public static T FillGeneralTypeExtendedPropertyCreationDto<T>(this T target, BaseExtendedPropertyModel from)
            where T : GeneralTypeExtendedPropertyCreationDto
        {
            target.IsRequired = ((BaseRequireableExtendedPropertyModel)from).IsRequired;

            return target.FillBaseExtendedPropertyDto(from);
        }

        public static T FillSecurityItemExtendedPropertyCreationDto<T>(this T target, BaseExtendedPropertyModel from)
            where T : SecurityItemExtendedPropertyCreationDto
        {
            target.IsRequired = ((BaseSequrityExtendedPropertyModel)from).IsRequired;

            return target.FillBaseExtendedPropertyDto(from);
        }

        public static T FillBaseExtendedPropertyModel<T>(this T target, ExtendedPropertyGetResultDto from)
            where T : BaseExtendedPropertyModel
        {
            target.Id = from.Id;
            target.CrmObjectTypeId = from.CrmObjectTypeId.ToString();
            target.PropertyTypeIndex = from.PropertyTypeIndex;

            target.UserKey = from.UserKey;
            target.DefaultValue = from.DefaultValue;
            target.Name = BaseInitServiceExtension.ToResourceValues(from.Name);
            target.ToolTip = BaseInitServiceExtension.ToResourceValues(from.Tooltip);

            return target;
        }

        public static T FillBaseRequireableExtendedPropertyModel<T>(this T target, ExtendedPropertyGetResultDto from)
            where T : BaseRequireableExtendedPropertyModel
        {
            target.IsRequired = from.IsRequired;

            return target.FillBaseExtendedPropertyModel(from);
        }

        public static ResourceValueDto ToDto(this ResourceValue resourceValue)
        {
            return new ResourceValueDto { Value = resourceValue.Value, LanguageCulture = resourceValue.LanguageCulture };
        }


    }
}
