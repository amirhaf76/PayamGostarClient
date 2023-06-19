using PayamGostarClient.ApiProvider;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeServiceDtos.Get;

namespace PayamGostarClient.ApiServices.Extension
{
    internal static class ExtendedPropertyExtraConfigExtension
    {
        internal static NumericExtendedPropertyExtraConfigDto ToDto(this NumericPropertyDefinitionExtraConfigs config)
        {
            return new NumericExtendedPropertyExtraConfigDto
            {
                DecimalDigits = config.DecimalDigits,
                MinDigits = config.MinDigits,
                MaxDigits = config.MaxDigits,
                MinValue = config.MinValue,
                MaxValue = config.MaxValue,
                ShowColumn = config.ShowColumn,

            };
        }

        internal static LabelExtendedPropertyExtraConfigDto ToDto(this LabelPropertyDefinitionExtraConfig config)
        {
            return new LabelExtendedPropertyExtraConfigDto
            {
                LabelText = config.LabelText,
                ColorName = config.ColorName,
                ColorIndex = config.ColorIndex,
                ShowTitle = config.ShowTitle,
                IconName = config.IconName,

            };
        }

        internal static CrmObjectMultiValueExtendedPropertyExtraConfigDto ToDto(this CrmObjectMultiValuePropertyDefinitionExtraConfigs config)
        {
            return new CrmObjectMultiValueExtendedPropertyExtraConfigDto
            {
                VisibleProperties = config.VisibleProperties,
                CrmObjectType = (CrmObjectModelInitServiceModels.CrmObjectModels.Gp_CrmObjectType)config.CrmObjectType,
                SubTypeId = config.SubTypeId,

            };
        }

        internal static CrmObjectReferencedTypeExtendedPropertyExtraConfigDto ToDto(this CrmObjectReferencedTypeExteraConfigs config)
        {
            return new CrmObjectReferencedTypeExtendedPropertyExtraConfigDto
            {
                CrmObjectTypeId = config.CrmObjectTypeId,
                PreventSettingContainerCrmobjectAsParent = config.PreventSettingContainerCrmobjectAsParent,

            };
        }


        internal static TextInvoiceDetailExtendedPropertyExtraConfigDto ToDto(this TextInvoiceDetailPropertyDefinitionExtraConfig config)
        {
            return new TextInvoiceDetailExtendedPropertyExtraConfigDto
            {
                ShowColumn = config.ShowColumn,
            };
        }
        internal static ImageExtendedPropertyExtraConfigDto ToDto(this ImagePropertyDefintionExtraConfigs config)
        {
            return new ImageExtendedPropertyExtraConfigDto
            {
                Height = config.Height,
                Width = config.Width,
            };
        }
        internal static SecurityItemExtendedPropertyExtraConfigDto ToDto(this SecurityItemPropertyDefinitionExtraConfigs config)
        {
            return new SecurityItemExtendedPropertyExtraConfigDto
            {
                ShowDeactiveMembersOption = config.ShowDeactiveMembersOption,
            };
        }
        internal static FileExtendedPropertyExtraConfigDto ToDto(this FilePropertyDefinitionExtraConfigs config)
        {
            return new FileExtendedPropertyExtraConfigDto
            {
                Extensions = config.Extensions,
                FileSizeType = (Dtos.ExtendedPropertyServiceDtos.FileSizeType)config.FileSizeType,
                MaxSize = config.MaxSize,
            };
        }
        internal static ImageFileExtendedPropertyExtraConfigDto ToDto(this ImageFilePropertyDefinitionExtraConfigs config)
        {
            return new ImageFileExtendedPropertyExtraConfigDto
            {
                Height = config.Height,
                Width = config.Width,
            };
        }
        internal static AutoNumberExtendedPropertyExtraConfigDto ToDto(this AutoNumberPropertyDefinitionExtraConfig config)
        {
            return new AutoNumberExtendedPropertyExtraConfigDto
            {
                Prefix = config.Prefix,
                Postfix = config.Postfix,
                Seed = config.Seed,
                Length = config.Length,
            };
        }
        internal static ProductListExtendedPropertyExtraConfigDto ToDto(this ProductListPropertyDefinitionExtraConfig config) 
        {
            return new ProductListExtendedPropertyExtraConfigDto
            {
                FractionLength = config.FractionLength,
                ShowAmountColumn = config.ShowAmountColumn,
                ShowDiscountColumn = config.ShowDiscountColumn,
                ShowUnitPriceColumn = config.ShowUnitPriceColumn,
                ShowFinalPriceColumn = config.ShowFinalPriceColumn,
            };
        }
        internal static CurrencyExtendedPropertyExtraConfigDto ToDto(this CurrencyPropertyDefinitionExtraConfig config)
        {
            return new CurrencyExtendedPropertyExtraConfigDto
            {
                IsBalance = config.IsBalance,
            };
        }

    }
}
