using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.ExtendedPropertyApiClientDtos;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.ExtendedPropertyApiClientDtos.MultiValueExtendedProperies;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.ExtendedPropertyApiClientDtos.SimpleExtendedProperies;
using SeptaPay.PayamGostarClient.Initializer.Core.CrmModels.ExtendedPropertyModels;
using System;
using System.Linq;

namespace SeptaPay.PayamGostarClient.Initializer.Core.Utilities.Extensions
{
    internal static class ExtendedPropertyModelExtension
    {
        public static TextExtendedPropertyCreationDto ToTextExtendedPropertyCreationDto(this BaseExtendedPropertyModel baseModel)
        {
            var model = (TextExtendedPropertyModel)baseModel;

            return new TextExtendedPropertyCreationDto
            {
                // CalculationTypeIndex = model.CalculationTypeIndex,
                IsMultiline = model.IsMultiLine,

            }.FillGeneralTypeExtendedPropertyCreationDto(baseModel);
        }

        public static FormExtendedPropertyCreationDto ToFormExtendedPropertyCreationDto(this BaseExtendedPropertyModel baseModel)
        {
            return new FormExtendedPropertyCreationDto().FillCrmItemExtendedPropertyCreationDto(baseModel);
        }

        public static DropDownListExtendedPropertyCreationDto ToDropDownListExtendedPropertyCreationDto(this BaseExtendedPropertyModel baseModel)
        {
            var model = (DropDownListExtendedPropertyModel)baseModel;

            return new DropDownListExtendedPropertyCreationDto
            {
                Values = model.Values?.Select(v => new DropDownListExtendedPropertyValueCreationDto
                {
                    PropertyDefinitionId = v.PropertyDefinitionId,
                    Value = v.Value
                }) ?? Array.Empty<DropDownListExtendedPropertyValueCreationDto>(),

            }.FillGeneralTypeExtendedPropertyCreationDto(baseModel);
        }

        public static UserExtendedPropertyCreationDto ToUserExtendedPropertyCreationDto(this BaseExtendedPropertyModel baseModel)
        {
            var model = (UserExtendedPropertyModel)baseModel;

            return new UserExtendedPropertyCreationDto
            {
                //ShowDeactiveMembersOption = model.ShowDeactiveMembersOption,
            }.FillSecurityItemExtendedPropertyCreationDto(baseModel);
        }

        public static NumberExtendedPropertyCreationDto ToNumberExtendedPropertyCreationDto(this BaseExtendedPropertyModel baseModel)
        {
            var model = (NumberExtendedPropertyModel)baseModel;

            return new NumberExtendedPropertyCreationDto
            {
                MinDigits = model.MinDigits,
                MaxDigits = model.MaxDigits,
                MinValue = model.MinValue,
                MaxValue = model.MaxValue,
                // CalculationTypeIndex = model.CalculationTypeIndex,
                DecimalDigits = model.DecimalDigits,

            }.FillGeneralTypeExtendedPropertyCreationDto(baseModel);
        }

        public static DepartmentExtendedPropertyCreationDto ToDepartmentExtendedPropertyCreationDto(this BaseExtendedPropertyModel baseModel)
        {
            return new DepartmentExtendedPropertyCreationDto().FillSecurityItemExtendedPropertyCreationDto(baseModel);
        }

        public static PositionExtendedPropertyCreationDto ToPositionExtendedPropertyCreationDto(this BaseExtendedPropertyModel baseModel)
        {
            return new PositionExtendedPropertyCreationDto().FillSecurityItemExtendedPropertyCreationDto(baseModel);
        }

        public static PersianDateExtendedPropertyCreationDto ToPersianDateExtendedPropertyCreationDto(this BaseExtendedPropertyModel baseModel)
        {
            return new PersianDateExtendedPropertyCreationDto().FillGeneralTypeExtendedPropertyCreationDto(baseModel);
        }

        public static LabelExtendedPropertyCreationDto ToLabelExtendedPropertyCreationDto(this BaseExtendedPropertyModel baseModel)
        {
            return new LabelExtendedPropertyCreationDto().FillBaseExtendedPropertyDto(baseModel);
        }

        public static CrmObjectMultiValueExtendedPropertyCreationDto ToCrmObjectMultiValueExtendedPropertyCreationDto(this BaseExtendedPropertyModel baseModel)
        {
            var model = (CrmObjectMultiValueExtendedPropertyModel)baseModel;

            return new CrmObjectMultiValueExtendedPropertyCreationDto
            {
                CrmObjectTypeIndex = (int)model.CrmObjectTypeIndex,
                SubTypeId = model.SubTypeId != null ? (Guid?)Guid.Parse(model.SubTypeId) : null,
                ShowInGridProps = model.ShowInGridProps?.Select(s => s.ToDto()) ?? Array.Empty<ExtendedPropertyIdWrapperDto>(),

            }.FillBaseExtendedPropertyDto(baseModel);
        }

        public static TimeExtendedPropertyCreationDto ToTimeExtendedPropertyCreationDto(this BaseExtendedPropertyModel baseModel)
        {
            return new TimeExtendedPropertyCreationDto().FillGeneralTypeExtendedPropertyCreationDto(baseModel);
        }

        public static CurrencyExtendedPropertyCreationDto ToCurrencyExtendedPropertyCreationDto(this BaseExtendedPropertyModel baseModel)
        {
            var model = (CurrencyExtendedPropertyModel)baseModel;

            return new CurrencyExtendedPropertyCreationDto
            {
                IsRequired = model.IsRequired,
                IsBalance = model.IsBalance,

            }.FillBaseExtendedPropertyDto(model);
        }

        public static FileExtendedPropertyCreationDto ToFileExtendedPropertyCreationDto(this BaseExtendedPropertyModel baseModel)
        {
            var model = (FileExtendedPropertyModel)baseModel;

            return new FileExtendedPropertyCreationDto
            {
                MaxFileSize = model.MaxFileSize,
                FileSizeTypeIndex = (int)model.FileSizeTypeIndex,
                FileExtensions = model.Extensions,

            }.FillBaseExtendedPropertyDto(model);
        }

        public static CheckboxExtendedPropertyCreationDto ToCheckboxExtendedPropertyCreationDto(this BaseExtendedPropertyModel baseModel)
        {
            var model = (CheckboxExtendedPropertyModel)baseModel;

            return new CheckboxExtendedPropertyCreationDto().FillBaseExtendedPropertyDto(model);
        }

        public static AppointmentExtendedPropertyCreationDto ToAppointmentExtendedPropertyCreationDto(this BaseExtendedPropertyModel baseModel)
        {
            var model = (AppointmentExtendedPropertyModel)baseModel;

            return new AppointmentExtendedPropertyCreationDto().FillCrmItemExtendedPropertyCreationDto(model);
        }

        public static SecurityItemExtendedPropertyCreationDto ToSecurityItemExtendedPropertyCreationDto(this BaseExtendedPropertyModel baseModel)
        {
            var model = (SecurityItemExtendedPropertyModel)baseModel;

            return new SecurityItemExtendedPropertyCreationDto().FillSecurityItemExtendedPropertyCreationDto(model);
        }

        public static AutoNumberExtendedPropertyCreationDto ToAutoNumberExtendedPropertyCreationDto(this BaseExtendedPropertyModel baseModel)
        {
            var model = (AutoNumberExtendedPropertyModel)baseModel;

            return new AutoNumberExtendedPropertyCreationDto
            {
                Prefix = model.Prefix,
                Postfix = model.Postfix,
                Seed = model.Seed,
                AutoNumLength = model.AutoNumLength,

            }.FillBaseExtendedPropertyDto(model);
        }

        public static CrmItemIdentityExtendedPropertyCreationDto ToCrmItemIdentityExtendedPropertyCreationDto(this BaseExtendedPropertyModel baseModel)
        {
            return new CrmItemIdentityExtendedPropertyCreationDto().FillSecurityItemExtendedPropertyCreationDto(baseModel);
        }
        public static GpExtendedPropertyCreationDto ToGpExtendedPropertyCreationDto(this BaseExtendedPropertyModel baseModel)
        {
            var model = (GpExtendedPropertyModel)baseModel;

            return new GpExtendedPropertyCreationDto
            {
                GpKey = model.GpKey,

            }.FillGeneralTypeExtendedPropertyCreationDto(baseModel);
        }
        public static GregorianDateExtendedPropertyCreationDto ToGregorianDateExtendedPropertyCreationDto(this BaseExtendedPropertyModel baseModel)
        {
            return new GregorianDateExtendedPropertyCreationDto().FillGeneralTypeExtendedPropertyCreationDto(baseModel);
        }
        public static HTMLExtendedPropertyCreationDto ToHTMLExtendedPropertyCreationDto(this BaseExtendedPropertyModel baseModel)
        {
            var model = (HtmlExtendedPropertyModel)baseModel;

            return new HTMLExtendedPropertyCreationDto
            {
                IsRequired = model.IsRequired,

            }.FillBaseExtendedPropertyDto(baseModel);
        }
        public static ImageExtendedPropertyCreationDto ToImageExtendedPropertyCreationDto(this BaseExtendedPropertyModel baseModel)
        {
            var model = (ImageExtendedPropertyModel)baseModel;

            return new ImageExtendedPropertyCreationDto
            {
                SupportedExtensions = model.SupportedExtensions,
                MaxSize = model.MaxSize,
                ImageWidth = model.ImageWidth,
                ImageHeight = model.ImageHeight,
                FileSizeTypeIndex = (int)model.FileSizeType,

            }.FillBaseExtendedPropertyDto(baseModel);
        }
        public static LinkExtendedPropertyCreationDto ToLinkExtendedPropertyCreationDto(this BaseExtendedPropertyModel baseModel)
        {
            return new LinkExtendedPropertyCreationDto().FillGeneralTypeExtendedPropertyCreationDto(baseModel);
        }
        public static MarketingCampaignExtendedPropertyCreationDto ToMarketingCampaignExtendedPropertyCreationDto(this BaseExtendedPropertyModel baseModel)
        {
            var model = (MarketingCampaignExtendedPropertyModel)baseModel;

            return new MarketingCampaignExtendedPropertyCreationDto
            {
                IsRequired = model.IsRequired,

            }.FillBaseExtendedPropertyDto(baseModel);
        }


        public static CurrencyMultiValueExtendedPropertyCreationDto ToCurrencyMultiValueExtendedPropertyCreationDto(this BaseExtendedPropertyModel baseModel)
        {
            return new CurrencyMultiValueExtendedPropertyCreationDto().FillBaseExtendedPropertyDto(baseModel);
        }
        public static FileMultiValueExtendedPropertyCreationDto ToFileMultiValueExtendedPropertyCreationDto(this BaseExtendedPropertyModel baseModel)
        {
            return new FileMultiValueExtendedPropertyCreationDto().FillBaseExtendedPropertyDto(baseModel);
        }
        public static GregorianDateMultiValueExtendedPropertyCreationDto ToGregorianDateMultiValueExtendedPropertyCreationDto(this BaseExtendedPropertyModel baseModel)
        {
            return new GregorianDateMultiValueExtendedPropertyCreationDto().FillBaseExtendedPropertyDto(baseModel);
        }
        public static IdentityMultiValueExtendedPropertyCreationDto ToIdentityMultiValueExtendedPropertyCreationDto(this BaseExtendedPropertyModel baseModel)
        {
            return new IdentityMultiValueExtendedPropertyCreationDto().FillBaseExtendedPropertyDto(baseModel);
        }
        public static LinkMultiValueExtendedPropertyCreationDto ToLinkMultiValueExtendedPropertyCreationDto(this BaseExtendedPropertyModel baseModel)
        {
            return new LinkMultiValueExtendedPropertyCreationDto().FillBaseExtendedPropertyDto(baseModel);
        }
        public static NumberMultiValueExtendedPropertyCreationDto ToNumberMultiValueExtendedPropertyCreationDto(this BaseExtendedPropertyModel baseModel)
        {
            var model = (NumberMultiValueExtendedPropertyModel)baseModel;

            return new NumberMultiValueExtendedPropertyCreationDto
            {
                DecimalDigits = model.DecimalDigits,
                MinDigit = model.MinDigit,
                MaxDigit = model.MaxDigit,
                MinValue = model.MinValue,
                MaxValue = model.MaxValue,

            }.FillBaseExtendedPropertyDto(baseModel);
        }
        public static PersianDateMultiValueExtendedPropertyCreationDto ToPersianDateMultiValueExtendedPropertyCreationDto(this BaseExtendedPropertyModel baseModel)
        {
            return new PersianDateMultiValueExtendedPropertyCreationDto().FillBaseExtendedPropertyDto(baseModel);
        }
        public static ProductMultiValueExtendedPropertyCreationDto ToProductMultiValueExtendedPropertyCreationDto(this BaseExtendedPropertyModel baseModel)
        {
            var model = (ProductMultiValueExtendedPropertyModel)baseModel;

            return new ProductMultiValueExtendedPropertyCreationDto
            {
                FractionLength = model.FractionLength,
                ShowAmountColumn = model.ShowAmountColumn,
                ShowDiscountColumn = model.ShowDiscountColumn,
                ShowUnitPriceColumn = model.ShowUnitPriceColumn,
                ShowFinalPriceColumn = model.ShowFinalColumn,

            };
        }
        public static SecurityItemMultiValueExtendedPropertyCreationDto ToSecurityItemMultiValueExtendedPropertyCreationDto(this BaseExtendedPropertyModel baseModel)
        {
            return new SecurityItemMultiValueExtendedPropertyCreationDto().FillBaseExtendedPropertyDto(baseModel);
        }
        public static TextMultiValueExtendedPropertyCreationDto ToTextMultiValueExtendedPropertyCreationDto(this BaseExtendedPropertyModel baseModel)
        {
            return new TextMultiValueExtendedPropertyCreationDto().FillBaseExtendedPropertyDto(baseModel);
        }
        public static UserMultiValueExtendedPropertyCreationDto ToUserMultiValueExtendedPropertyCreationDto(this BaseExtendedPropertyModel baseModel)
        {
            var model = (UserMultiValueExtendedPropertyModel)baseModel;

            return new UserMultiValueExtendedPropertyCreationDto
            {
                ShowDeactiveMembersOption = model.ShowDeactiveMembersOption,

            }.FillBaseExtendedPropertyDto(baseModel);
        }


        public static ExtendedPropertyIdWrapperDto ToDto(this PropertyDefinitionIdWrapperModel model)
        {
            return new ExtendedPropertyIdWrapperDto { Id = Guid.Parse(model.Id) };
        }

    }
}
