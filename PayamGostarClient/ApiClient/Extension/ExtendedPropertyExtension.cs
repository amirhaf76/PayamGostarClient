using PayamGostarClient.ApiProvider;
using System.Linq;
using PayamGostarClient.ApiClient.Dtos.ExtendedPropertyApiClientDtos.SimpleExtendedProperies;
using PayamGostarClient.ApiClient.Dtos.ExtendedPropertyApiClientDtos.MultiValueExtendedProperies;
using PayamGostarClient.ApiClient.Models.Customization.ExtendedProperty;

namespace PayamGostarClient.ApiClient.Extension
{
    internal static class ExtendedPropertyExtension
    {
        internal static AutoNumerPropertyDefinitionCreateVM ToVM(this AutoNumberExtendedPropertyCreationDto dto)
        {
            return new AutoNumerPropertyDefinitionCreateVM()
            {
                Prefix = dto.Prefix,
                Postfix = dto.Postfix,
                Seed = dto.Seed,
                AutoNumLength = dto.AutoNumLength,
            }.FillBasePropertyDefinitionCreateVM(dto);
        }

        internal static CheckboxPropertyDefinitionCreateVM ToVM(this CheckboxExtendedPropertyCreationDto dto)
        {
            return new CheckboxPropertyDefinitionCreateVM
            {

            }.FillGeneralTypePropertyDefinitionCreateVM(dto);
        }


        internal static ColorPropertyDefinitionCreateVM ToVM(this ColorExtendedPropertyCreationDto dto)
        {
            return new ColorPropertyDefinitionCreateVM().FillBasePropertyDefinitionCreateVM(dto);
        }

        internal static CrmItemIdentityPropertyDefinitionCreateVM ToVM(this CrmItemIdentityExtendedPropertyCreationDto dto)
        {
            return new CrmItemIdentityPropertyDefinitionCreateVM
            {
                IsRequired = dto.IsRequired,
            }.FillBasePropertyDefinitionCreateVM(dto);
        }

        internal static CrmItemPropertyDefinitionCreateVM ToVM(this CrmItemExtendedPropertyCreationDto dto)
        {
            return new CrmItemPropertyDefinitionCreateVM().FillCrmItemPropertyDefinitionCreateVM(dto);
        }

        internal static CrmObjectMultiValuePropertyDefinitionCreateVM ToVM(this CrmObjectMultiValueExtendedPropertyCreationDto dto)
        {
            return new CrmObjectMultiValuePropertyDefinitionCreateVM
            {
                CrmObjectTypeId = dto.CrmObjectTypeId,
                CrmObjectTypeIndex = dto.CrmObjectTypeIndex,
                SubTypeId = dto.SubTypeId,
                ShowInGridProps = dto.ShowInGridProps.Select(p => p.ToVM()),

            }.FillBaseMultiValuePropertyDefinitionVM(dto);
        }

        internal static CurrencyMultiValuePropertyDefinitionCreateVM ToVM(this CurrencyMultiValueExtendedPropertyCreationDto dto)
        {
            return new CurrencyMultiValuePropertyDefinitionCreateVM().FillGeneralMultiValuePropertyDefinitionCreateVM(dto);
        }

        internal static CurrencyPropertyDefinitionCreateVM ToVM(this CurrencyExtendedPropertyCreationDto dto)
        {
            return new CurrencyPropertyDefinitionCreateVM
            {
                IsRequired = dto.IsRequired,
                IsBalance = dto.IsBalance,
                CalculationTypeIndex = dto.CalculationTypeIndex,

            }.FillBasePropertyDefinitionCreateVM(dto);
        }

        internal static DropDownListPropertyDefinitionCreateVM ToVM(this DropDownListExtendedPropertyCreationDto dto)
        {
            return new DropDownListPropertyDefinitionCreateVM().FillGeneralTypePropertyDefinitionCreateVM(dto);
        }

        internal static DropDownListPropertyDefinitionValueCreateVM ToVM(this DropDownListExtendedPropertyValueCreationDto dto)
        {
            return new DropDownListPropertyDefinitionValueCreateVM
            {
                PropertyDefinitionId = dto.PropertyDefinitionId,
                Value = dto.Value,
            };
        }

        internal static FileMultiValuePropertyDefinitionCreateVM ToVM(this FileMultiValueExtendedPropertyCreationDto dto)
        {
            return new FileMultiValuePropertyDefinitionCreateVM
            {
                MaxFileSize = dto.MaxFileSize,
                FileSizeTypeIndex = dto.FileSizeTypeIndex,
                FileExtensions = dto.FileExtensions,

            }.FillGeneralMultiValuePropertyDefinitionCreateVM(dto);
        }

        internal static FilePropertyDefinitionCreateVM ToVM(this FileExtendedPropertyCreationDto dto)
        {
            return new FilePropertyDefinitionCreateVM
            {
                MaxFileSize = dto.MaxFileSize,
                FileSizeTypeIndex = dto.FileSizeTypeIndex,
                FileExtensions = dto.FileExtensions,

            }.FillBasePropertyDefinitionCreateVM(dto);
        }

        internal static GpPropertyDefinitionCreateVM ToVM(this GpExtendedPropertyCreationDto dto)
        {
            return new GpPropertyDefinitionCreateVM
            {
                GpKey = dto.GpKey,

            }.FillGeneralTypePropertyDefinitionCreateVM(dto);
        }

        internal static GregorianDateMultiValuePropertyDefinitionCreateVM ToVM(this GregorianDateMultiValueExtendedPropertyCreationDto dto)
        {
            return new GregorianDateMultiValuePropertyDefinitionCreateVM().FillBaseMultiValuePropertyDefinitionVM(dto);
        }

        internal static GregorianDatePropertyDefinitionCreateVM ToVM(this GregorianDateExtendedPropertyCreationDto dto)
        {
            return new GregorianDatePropertyDefinitionCreateVM().FillGeneralTypePropertyDefinitionCreateVM(dto);
        }

        internal static HTMLPropertyDefinitionCreateVM ToVM(this HTMLExtendedPropertyCreationDto dto)
        {
            return new HTMLPropertyDefinitionCreateVM
            {
                IsRequired = dto.IsRequired,

            }.FillBasePropertyDefinitionCreateVM(dto);
        }

        internal static IdentityMultiValuePropertyDefinitionCreateVM ToVM(this IdentityMultiValueExtendedPropertyCreationDto dto)
        {
            return new IdentityMultiValuePropertyDefinitionCreateVM
            {
                ShowInGridProps = dto.ShowInGridProps?.Select(x => x.ToVM()),

            }.FillGeneralMultiValuePropertyDefinitionCreateVM(dto);
        }

        internal static ImagePropertyDefinitionCreateVM ToVM(this ImageExtendedPropertyCreationDto dto)
        {
            return new ImagePropertyDefinitionCreateVM
            {
                MaxSize = dto.MaxSize,
                ImageWidth = dto.ImageWidth,
                ImageHeight = dto.ImageHeight,
                FileSizeTypeIndex = dto.FileSizeTypeIndex,

            }.FillBasePropertyDefinitionCreateVM(dto);
        }

        internal static LabelPropertyDefinitionCreateVM ToVM(this LabelExtendedPropertyCreationDto dto)
        {
            return new LabelPropertyDefinitionCreateVM
            {
                CalculationTypeIndex = dto.CalculationTypeIndex,
                LabelText = dto.LabelText,
                ColorId = dto.ColorId,
                ShowTitleTypeIndex = dto.ShowTitleTypeIndex,
                IconName = dto.IconName,
            }.FillBasePropertyDefinitionCreateVM(dto);
        }

        internal static LinkMultiValuePropertyDefinitionCreateVM ToVM(this LinkMultiValueExtendedPropertyCreationDto dto)
        {
            return new LinkMultiValuePropertyDefinitionCreateVM().FillGeneralMultiValuePropertyDefinitionCreateVM(dto);
        }

        internal static LinkPropertyDefinitionCreateVM ToVM(this LinkExtendedPropertyCreationDto dto)
        {
            return new LinkPropertyDefinitionCreateVM().FillGeneralTypePropertyDefinitionCreateVM(dto);
        }

        internal static MarketingCampaignPropertyDefinitionCreateVM ToVM(this MarketingCampaignExtendedPropertyCreationDto dto)
        {
            return new MarketingCampaignPropertyDefinitionCreateVM
            {
                IsRequired = dto.IsRequired,

            }.FillBasePropertyDefinitionCreateVM(dto);
        }

        internal static NumberMultiValuePropertyDefinitionCreateVM ToVM(this NumberMultiValueExtendedPropertyCreationDto dto)
        {
            return new NumberMultiValuePropertyDefinitionCreateVM().FillGeneralMultiValuePropertyDefinitionCreateVM(dto);
        }

        internal static NumberPropertyDefinitionCreateVM ToVM(this NumberExtendedPropertyCreationDto dto)
        {
            return new NumberPropertyDefinitionCreateVM
            {
                DecimalDigits = dto.DecimalDigits,
                MinDigits = dto.MinDigits,
                MaxDigits = dto.MaxDigits,
                MinValue = dto.MinValue,
                MaxValue = dto.MaxValue,

            }.FillGeneralTypePropertyDefinitionCreateVM(dto);
        }

        internal static PersianDateMultiValuePropertyDefinitionCreateVM ToVM(this PersianDateMultiValueExtendedPropertyCreationDto dto)
        {
            return new PersianDateMultiValuePropertyDefinitionCreateVM().FillGeneralMultiValuePropertyDefinitionCreateVM(dto);
        }

        internal static PersianDatePropertyDefinitionCreateVM ToVM(this PersianDateExtendedPropertyCreationDto dto)
        {
            return new PersianDatePropertyDefinitionCreateVM().FillGeneralTypePropertyDefinitionCreateVM(dto);
        }

        internal static ProductMultiValuePropertyDefinitionCreateVM ToVM(this ProductMultiValueExtendedPropertyCreationDto dto)
        {
            return new ProductMultiValuePropertyDefinitionCreateVM
            {
                FractionLength = dto.FractionLength,
                ShowAmountColumn = dto.ShowAmountColumn,
                ShowDiscountColumn = dto.ShowDiscountColumn,
                ShowUnitPriceColumn = dto.ShowUnitPriceColumn,
                ShowFinalPriceColumn = dto.ShowFinalPriceColumn,

            }.FillGeneralMultiValuePropertyDefinitionCreateVM(dto);
        }

        internal static SecurityItemMultiValuePropertyDefinitionCreateVM ToVM(this SecurityItemMultiValueExtendedPropertyCreationDto dto)
        {
            return new SecurityItemMultiValuePropertyDefinitionCreateVM().FillGeneralMultiValuePropertyDefinitionCreateVM(dto);
        }

        internal static SecurityItemPropertyDefinitionCreateVM ToVM(this SecurityItemExtendedPropertyCreationDto dto)
        {
            return new SecurityItemPropertyDefinitionCreateVM
            {
                IsRequired = dto.IsRequired,
                
            }.FillBasePropertyDefinitionCreateVM(dto);
        }

        internal static TextMultiValuePropertyDefinitionCreateVM ToVM(this TextMultiValueExtendedPropertyCreationDto dto)
        {
            return new TextMultiValuePropertyDefinitionCreateVM().FillGeneralMultiValuePropertyDefinitionCreateVM(dto);
        }

        internal static TextPropertyDefinitionCreateVM ToVM(this TextExtendedPropertyCreationDto dto)
        {
            return new TextPropertyDefinitionCreateVM
            {
                IsMultiline = dto.IsMultiline,
            }.FillGeneralTypePropertyDefinitionCreateVM(dto);
        }

        internal static TimePropertyDefinitionCreateVM ToVM(this TimeExtendedPropertyCreationDto dto)
        {
            return new TimePropertyDefinitionCreateVM().FillGeneralTypePropertyDefinitionCreateVM(dto);
        }

        internal static UserMultiValuePropertyDefinitionCreateVM ToVM(this UserMultiValueExtendedPropertyCreationDto dto)
        {
            return new UserMultiValuePropertyDefinitionCreateVM
            {
                ShowDeactiveMembersOption = dto.ShowDeactiveMembersOption,

            }.FillGeneralMultiValuePropertyDefinitionCreateVM(dto);
        }

        internal static UserPropertyDefinitionCreateVM ToVM(this UserExtendedPropertyCreationDto dto)
        {
            return new UserPropertyDefinitionCreateVM
            {
                ShowDeactiveMembersOption = dto.ShowDeactiveMembersOption,
                IsRequired = dto.IsRequired,
                
            }.FillBasePropertyDefinitionCreateVM(dto);
        }


        internal static DropDownListValueResultDto ToDto(this PropertyDefinitionValueGetResultVM vm)
        {
            return new DropDownListValueResultDto
            {
                Id = vm.Id,
                DisplayIndex = vm.DisplayIndex,
                Index = vm.Index,
                PropertyDefinitionId = vm.PropertyDefinitionId,
                Value = vm.Value,
            };
        }

        internal static DropDownListPropertyDefinitionValueGetRequestVM ToVM(this DropDownListValueRequestDto dto)
        {
            return new DropDownListPropertyDefinitionValueGetRequestVM
            {
                Id = dto.Id,
            };
        }

    }
}
