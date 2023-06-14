using PayamGostarClient.ApiProvider;
using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos;
using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.BaseStructure;
using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.BaseStructure.MultiValue;
using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.BaseStructure.Simple;

namespace PayamGostarClient.ApiServices.Extension
{
    internal static class BaseExtendedPropertyExtension
    {
        public static T FillBasePropertyDefinitionVM<T>(this T target, BaseExtendedPropertyDto from)
            where T: BasePropertyDefinitionVM
        {
            target.Name = from.Name.ToLocalizedResourceDto();
            target.ToolTip = from.ToolTip.ToLocalizedResourceDto();
            target.PropertyGroupId = from.PropertyGroupId;
            target.DefaultValue = from.DefaultValue;
            target.UserKey = from.UserKey;

            return target;
        }

        public static T FillBasePropertyDefinitionCreateVM<T>(this T target, BaseExtendedPropertyCreationDto from)
            where T: BasePropertyDefinitionCreateVM
        {
            target = target.FillBasePropertyDefinitionVM(from);

            target.CrmObjectTypeId = from.CrmObjectTypeId;

            return target;
        }
        public static T FillCrmItemPropertyDefinitionCreateVM<T>(this T target, CrmItemExtendedPropertyCreationDto from)
            where T : CrmItemPropertyDefinitionCreateVM
        {
            target = target.FillBasePropertyDefinitionVM(from);

            target.CrmObjectTypeId = from.CrmObjectTypeId;

            return target;
        }

        public static T FillGeneralTypePropertyDefinitionCreateVM<T>(this T target, GeneralTypeExtendedPropertyCreationDto from)
            where T: GeneralTypePropertyDefinitionCreateVM
        {
            target = target.FillBasePropertyDefinitionCreateVM(from);

            target.IsRequired = from.IsRequired;
            target.CalculationTypeIndex = from.CalculationTypeIndex;

            return target;
        }

        public static T FillBaseMultiValuePropertyDefinitionVM<T>(this T target, BaseMultiValueExtendedPropertyDto from)
            where T: BaseMultiValuePropertyDefinitionVM
        {
            target.Name = from.Name.ToLocalizedResourceDto();
            target.ToolTip = from.ToolTip.ToLocalizedResourceDto();
            target.PropertyGroupId = from.PropertyGroupId;
            target.UserKey = from.UserKey;

            return target;
        }

        public static T CopyGeneralMultiValuePropertyDefinitionCreateVM<T>(this T target, GeneralMultiValueExtendedPropertyCreationDto from)
            where T: GeneralMultiValuePropertyDefinitionCreateVM
        {
            target = target.FillBaseMultiValuePropertyDefinitionVM(from);

            target.CrmObjectTypeId = from.CrmObjectTypeId;

            return target;
        }
    }
}
