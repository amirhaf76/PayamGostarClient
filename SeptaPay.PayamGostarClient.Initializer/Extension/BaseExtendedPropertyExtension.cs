using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.ExtendedPropertyApiClientDtos.BaseStructure.MultiValue;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.ExtendedPropertyApiClientDtos.BaseStructure.Simple;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.ExtendedPropertyApiClientDtos.SimpleExtendedProperies;
using SeptaPay.PayamGostarClient.RestApi;

namespace SeptaPay.PayamGostarClient.Initializer.Extension
{
    internal static class BaseExtendedPropertyExtension
    {
        public static T FillBasePropertyDefinitionVM<T>(this T target, BaseExtendedPropertyDto from)
            where T : BasePropertyDefinitionVM
        {
            target.Name = from.Name.ToLocalizedResourceDto();
            target.ToolTip = from.ToolTip.ToLocalizedResourceDto();
            target.PropertyGroupId = from.PropertyGroupId;
            target.DefaultValue = from.DefaultValue;
            target.UserKey = from.UserKey;

            return target;
        }

        public static T FillBasePropertyDefinitionCreateVM<T>(this T target, BaseExtendedPropertyCreationDto from)
            where T : BasePropertyDefinitionCreateVM
        {
            target.CrmObjectTypeId = from.CrmObjectTypeId;

            return target.FillBasePropertyDefinitionVM(from);
        }
        public static T FillCrmItemPropertyDefinitionCreateVM<T>(this T target, CrmItemExtendedPropertyCreationDto from)
            where T : CrmItemPropertyDefinitionCreateVM
        {
            target.ReferencedItemCrmObjectTypeId = from.ReferencedItemCrmObjectTypeId;
            target.PreventSettingContainerCrmobjectAsParent = from.PreventSettingContainerCrmobjectAsParent;

            return target.FillBasePropertyDefinitionCreateVM(from);
        }

        public static T FillGeneralTypePropertyDefinitionCreateVM<T>(this T target, GeneralTypeExtendedPropertyCreationDto from)
            where T : GeneralTypePropertyDefinitionCreateVM
        {
            target.IsRequired = from.IsRequired;
            target.CalculationTypeIndex = from.CalculationTypeIndex;

            return target.FillBasePropertyDefinitionCreateVM(from);
        }

        public static T FillBaseMultiValuePropertyDefinitionVM<T>(this T target, BaseMultiValueExtendedPropertyDto from)
            where T : BaseMultiValuePropertyDefinitionVM
        {
            target.Name = from.Name.ToLocalizedResourceDto();
            target.ToolTip = from.ToolTip.ToLocalizedResourceDto();
            target.PropertyGroupId = from.PropertyGroupId;
            target.UserKey = from.UserKey;

            return target;
        }

        public static T FillGeneralMultiValuePropertyDefinitionCreateVM<T>(this T target, GeneralMultiValueExtendedPropertyCreationDto from)
            where T : GeneralMultiValuePropertyDefinitionCreateVM
        {
            target.CrmObjectTypeId = from.CrmObjectTypeId;

            return target.FillBaseMultiValuePropertyDefinitionVM(from);
        }
    }
}
