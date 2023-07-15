using PayamGostarClient.ApiClient.Dtos.ExtendedPropertyApiClientDtos;
using PayamGostarClient.ApiClient.Dtos.ExtendedPropertyApiClientDtos.MultiValueExtendedProperies;
using PayamGostarClient.ApiClient.Dtos.ExtendedPropertyApiClientDtos.SimpleExtendedProperies;
using PayamGostarClient.Initializer.CrmModels.ExtendedPropertyModels;
using System;
using System.Linq;

namespace PayamGostarClient.Initializer.Utilities.Extensions
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

        public static ExtendedPropertyIdWrapperDto ToDto(this PropertyDefinitionIdWrapperModel model)
        {
            return new ExtendedPropertyIdWrapperDto { Id = Guid.Parse(model.Id) };
        }

    }
}
