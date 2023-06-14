using PayamGostarClient.ApiProvider;
using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos;
using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.MultiValueExtendedProperies;
using System.Linq;

namespace PayamGostarClient.ApiServices.Extension
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
            return new CheckboxPropertyDefinitionCreateVM().FillGeneralTypePropertyDefinitionCreateVM(dto);
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
            }.FillCrmItemPropertyDefinitionCreateVM(dto);
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
            return new CurrencyMultiValuePropertyDefinitionCreateVM();
        }

        internal static CurrencyPropertyDefinitionCreateVM ToVM(this CurrencyExtendedPropertyCreationDto dto)
        {
            return new CurrencyPropertyDefinitionCreateVM();
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
            return new FileMultiValuePropertyDefinitionCreateVM();
        }

        internal static FilePropertyDefinitionCreateVM ToVM(this FileExtendedPropertyCreationDto dto)
        {
            return new FilePropertyDefinitionCreateVM();
        }

        internal static GpPropertyDefinitionCreateVM ToVM(this GpExtendedPropertyCreationDto dto)
        {
            return new GpPropertyDefinitionCreateVM();
        }

        internal static GregorianDateMultiValuePropertyDefinitionCreateVM ToVM(this GregorianDateMultiValueExtendedPropertyCreationDto dto)
        {
            return new GregorianDateMultiValuePropertyDefinitionCreateVM();
        }

        internal static GregorianDatePropertyDefinitionCreateVM ToVM(this GregorianDateExtendedPropertyCreationDto dto)
        {
            return new GregorianDatePropertyDefinitionCreateVM();
        }

        internal static HTMLPropertyDefinitionCreateVM ToVM(this HTMLExtendedPropertyCreationDto dto)
        {
            return new HTMLPropertyDefinitionCreateVM();
        }

        internal static IdentityMultiValuePropertyDefinitionCreateVM ToVM(this IdentityMultiValueExtendedPropertyCreationDto dto)
        {
            return new IdentityMultiValuePropertyDefinitionCreateVM();
        }

        internal static ImagePropertyDefinitionCreateVM ToVM(this ImageExtendedPropertyCreationDto dto)
        {
            return new ImagePropertyDefinitionCreateVM();
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
            return new LinkMultiValuePropertyDefinitionCreateVM();
        }

        internal static LinkPropertyDefinitionCreateVM ToVM(this LinkExtendedPropertyCreationDto dto)
        {
            return new LinkPropertyDefinitionCreateVM();
        }

        internal static MarketingCampaignPropertyDefinitionCreateVM ToVM(this MarketingCampaignExtendedPropertyCreationDto dto)
        {
            return new MarketingCampaignPropertyDefinitionCreateVM();
        }

        internal static NumberMultiValuePropertyDefinitionCreateVM ToVM(this NumberMultiValueExtendedPropertyCreationDto dto)
        {
            return new NumberMultiValuePropertyDefinitionCreateVM();
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
            return new PersianDateMultiValuePropertyDefinitionCreateVM();
        }

        internal static PersianDatePropertyDefinitionCreateVM ToVM(this PersianDateExtendedPropertyCreationDto dto)
        {
            return new PersianDatePropertyDefinitionCreateVM().FillGeneralTypePropertyDefinitionCreateVM(dto);
        }

        internal static ProductMultiValuePropertyDefinitionCreateVM ToVM(this ProductMultiValueExtendedPropertyCreationDto dto)
        {
            return new ProductMultiValuePropertyDefinitionCreateVM();
        }

        internal static SecurityItemMultiValuePropertyDefinitionCreateVM ToVM(this SecurityItemMultiValueExtendedPropertyCreationDto dto)
        {
            return new SecurityItemMultiValuePropertyDefinitionCreateVM();
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
            return new TextMultiValuePropertyDefinitionCreateVM();
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
            return new TimePropertyDefinitionCreateVM();
        }

        internal static UserMultiValuePropertyDefinitionCreateVM ToVM(this UserMultiValueExtendedPropertyCreationDto dto)
        {
            return new UserMultiValuePropertyDefinitionCreateVM();
        }

        internal static UserPropertyDefinitionCreateVM ToVM(this UserExtendedPropertyCreationDto dto)
        {
            return new UserPropertyDefinitionCreateVM
            {
                ShowDeactiveMembersOption = dto.ShowDeactiveMembersOption,
            }.FillBasePropertyDefinitionCreateVM(dto);
        }
    }
}
