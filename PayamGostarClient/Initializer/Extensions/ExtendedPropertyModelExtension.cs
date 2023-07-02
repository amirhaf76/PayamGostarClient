using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos;
using PayamGostarClient.ApiClient.Dtos.ExtendedPropertyApiClientDtos;
using PayamGostarClient.ApiClient.Dtos.ExtendedPropertyApiClientDtos.MultiValueExtendedProperies;
using PayamGostarClient.ApiClient.Dtos.ExtendedPropertyApiClientDtos.SimpleExtendedProperies;
using PayamGostarClient.ApiClient.Enums;
using PayamGostarClient.Initializer.CrmModels.ExtendedPropertyModels;
using PayamGostarClient.Initializer.Exceptions;
using System;
using System.Linq;

namespace PayamGostarClient.Initializer.Extensions
{
    internal static class ExtendedPropertyModelExtension
    {
        public static TextExtendedPropertyCreationDto ToTextExtendedPropertyCreationDto(this BaseExtendedPropertyModel baseModel)
        {
            var model = (TextExtendedPropertyModel)baseModel;

            return new TextExtendedPropertyCreationDto
            {
                IsRequired = model.IsRequired,
                // CalculationTypeIndex = model.CalculationTypeIndex,
                IsMultiline = model.IsMultiLine,

            }.FillBaseExtendedPropertyDto(baseModel);
        }

        public static FormExtendedPropertyCreationDto ToFormExtendedPropertyCreationDto(this BaseExtendedPropertyModel baseModel)
        {
            var model = (FormExtendedPropertyModel)baseModel;

            return new FormExtendedPropertyCreationDto
            {
                // todo: DoesPreventSettingParent = model.DoesPreventSettingParent,
            }.FillBaseExtendedPropertyDto(baseModel);
        }

        public static DropDownListExtendedPropertyCreationDto ToDropDownListExtendedPropertyCreationDto(this BaseExtendedPropertyModel baseModel)
        {
            var model = (DropDownListExtendedPropertyModel)baseModel;

            return new DropDownListExtendedPropertyCreationDto
            {
                IsRequired = model.IsRequired,
                Values = model.Values?.Select(v => new DropDownListExtendedPropertyValueCreationDto
                {
                    PropertyDefinitionId = v.PropertyDefinitionId,
                    Value = v.Value
                }) ?? Array.Empty<DropDownListExtendedPropertyValueCreationDto>(),

            }.FillBaseExtendedPropertyDto(baseModel);
        }

        public static UserExtendedPropertyCreationDto ToUserExtendedPropertyCreationDto(this BaseExtendedPropertyModel baseModel)
        {
            var model = (UserExtendedPropertyModel)baseModel;

            return new UserExtendedPropertyCreationDto
            {
                //ShowDeactiveMembersOption = model.ShowDeactiveMembersOption,
                IsRequired = model.IsRequired,

            }.FillBaseExtendedPropertyDto(baseModel);
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
                IsRequired = model.IsRequired,
                // CalculationTypeIndex = model.CalculationTypeIndex,
                DecimalDigits = model.DecimalDigits,

            }.FillBaseExtendedPropertyDto(baseModel);
        }

        public static DepartmentExtendedPropertyCreationDto ToDepartmentExtendedPropertyCreationDto(this BaseExtendedPropertyModel baseModel)
        {
            var model = (DepartmentExtendedPropertyModel)baseModel;

            return new DepartmentExtendedPropertyCreationDto
            {
                IsRequired = model.IsRequired,

            }.FillBaseExtendedPropertyDto(baseModel);
        }

        public static PositionExtendedPropertyCreationDto ToPositionExtendedPropertyCreationDto(this BaseExtendedPropertyModel baseModel)
        {
            var model = (PositionExtendedPropertyModel)baseModel;

            return new PositionExtendedPropertyCreationDto
            {
                IsRequired = model.IsRequired,

            }.FillBaseExtendedPropertyDto(baseModel);
        }

        public static PersianDateExtendedPropertyCreationDto ToPersianDateExtendedPropertyCreationDto(this BaseExtendedPropertyModel baseModel)
        {
            var model = (PersianDateExtendedPropertyModel)baseModel;

            return new PersianDateExtendedPropertyCreationDto
            {
                IsRequired = model.IsRequired,
            }.FillBaseExtendedPropertyDto(baseModel);
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
            var model = (TimeExtendedPropertyModel)baseModel;

            return new TimeExtendedPropertyCreationDto
            {
                IsRequired = model.IsRequired,

            }.FillBaseExtendedPropertyDto(model);
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

            return new AppointmentExtendedPropertyCreationDto().FillBaseExtendedPropertyDto(model);
        }

        public static SecurityItemExtendedPropertyCreationDto ToSecurityItemExtendedPropertyCreationDto(this BaseExtendedPropertyModel baseModel)
        {
            var model = (SecurityItemExtendedPropertyModel)baseModel;

            return new SecurityItemExtendedPropertyCreationDto
            {
                IsRequired = model.IsRequired,

            }.FillBaseExtendedPropertyDto(model);
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

        public static BaseExtendedPropertyModel ToModel(this ExtendedPropertyGetResultDto dto)
        {

            switch ((Gp_ExtendedPropertyType)dto.PropertyDisplayTypeIndex)
            {
                case Gp_ExtendedPropertyType.Text:
                    return new TextExtendedPropertyModel().FillBaseExtendedPropertyModel(dto);
                case Gp_ExtendedPropertyType.Form:
                    // todo: DoesPreventSettingParent
                    return new FormExtendedPropertyModel().FillBaseExtendedPropertyModel(dto);
                case Gp_ExtendedPropertyType.DropDownList:
                    return new DropDownListExtendedPropertyModel().FillBaseExtendedPropertyModel(dto);
                case Gp_ExtendedPropertyType.User:
                    return new UserExtendedPropertyModel().FillBaseExtendedPropertyModel(dto);
                case Gp_ExtendedPropertyType.Number:
                    return new NumberExtendedPropertyModel().FillBaseExtendedPropertyModel(dto);
                case Gp_ExtendedPropertyType.Department:
                    return new DepartmentExtendedPropertyModel().FillBaseExtendedPropertyModel(dto);
                case Gp_ExtendedPropertyType.Position:
                    return new PositionExtendedPropertyModel().FillBaseExtendedPropertyModel(dto);
                case Gp_ExtendedPropertyType.Date:
                    return new PersianDateExtendedPropertyModel().FillBaseExtendedPropertyModel(dto);
                case Gp_ExtendedPropertyType.Label:
                    return new LabelExtendedPropertyModel().FillBaseExtendedPropertyModel(dto);
                case Gp_ExtendedPropertyType.CrmObjectMultiValue:
                    return new CrmObjectMultiValueExtendedPropertyModel().FillBaseExtendedPropertyModel(dto);
                case Gp_ExtendedPropertyType.Time:
                    return new TimeExtendedPropertyModel().FillBaseExtendedPropertyModel(dto);
                case Gp_ExtendedPropertyType.Currency:
                    return new CurrencyExtendedPropertyModel().FillBaseExtendedPropertyModel(dto);
                case Gp_ExtendedPropertyType.File:
                    return new FileExtendedPropertyModel().FillBaseExtendedPropertyModel(dto);
                case Gp_ExtendedPropertyType.Checkbox:
                    return new CheckboxExtendedPropertyModel().FillBaseExtendedPropertyModel(dto);
                case Gp_ExtendedPropertyType.Appointment:
                    return new AppointmentExtendedPropertyModel().FillBaseExtendedPropertyModel(dto);
                case Gp_ExtendedPropertyType.SecurityItem:
                    return new SecurityItemExtendedPropertyModel().FillBaseExtendedPropertyModel(dto);
                case Gp_ExtendedPropertyType.AutoNumber:
                    return new AutoNumberExtendedPropertyModel().FillBaseExtendedPropertyModel(dto);
                default:
                    throw new NotFoundExtendedPropertyTypeException($"PropertyDisplayType: '{(Gp_ExtendedPropertyType)dto.PropertyDisplayTypeIndex}'.");
            }
        }

        public static NumberExtendedPropertyModel ToNumberExtendedPropertyModel(this ExtendedPropertyGetResultDto dto)
        {
            var extraConfig = (NumericExtendedPropertyExtraConfigDto)dto.ExtraConfig;

            return new NumberExtendedPropertyModel
            {
                MinDigits = extraConfig.MinDigits,
                MaxDigits = extraConfig.MaxDigits,
                MinValue = extraConfig.MinValue,
                MaxValue = extraConfig.MaxValue,
                DecimalDigits = extraConfig.DecimalDigits,

            }.FillBaseExtendedPropertyModel(dto);
        }

        public static TextExtendedPropertyModel ToTextExtendedPropertyModel(this ExtendedPropertyGetResultDto dto)
        {
            return new TextExtendedPropertyModel
            {
                // todo: Can not get isMultiLine from api.
            }.FillBaseExtendedPropertyModel(dto);
        }

        public static DropDownListExtendedPropertyModel ToDropDownListExtendedPropertyModel(this ExtendedPropertyGetResultDto dto)
        {
            return new DropDownListExtendedPropertyModel
            {

            }.FillBaseExtendedPropertyModel(dto);
        }

        public static UserExtendedPropertyModel ToUserExtendedPropertyModel(this ExtendedPropertyGetResultDto dto)
        {
            return new UserExtendedPropertyModel
            {

            }.FillBaseExtendedPropertyModel(dto);
        }

        public static FormExtendedPropertyModel ToFormExtendedPropertyModel(this ExtendedPropertyGetResultDto dto)
        {
            return new FormExtendedPropertyModel
            {
                // todo DoesPreventSettingParent = dto.DoesPreventSettingParent,
            }.FillBaseExtendedPropertyModel(dto);
        }

        public static DepartmentExtendedPropertyModel ToDepartmentExtendedPropertyModel(this ExtendedPropertyGetResultDto dto)
        {
            return new DepartmentExtendedPropertyModel
            {

            }.FillBaseExtendedPropertyModel(dto);
        }

        public static PositionExtendedPropertyModel ToPositionExtendedPropertyModel(this ExtendedPropertyGetResultDto dto)
        {
            return new PositionExtendedPropertyModel
            {

            }.FillBaseExtendedPropertyModel(dto);
        }

        public static PersianDateExtendedPropertyModel ToPersianDateExtendedPropertyModel(this ExtendedPropertyGetResultDto dto)
        {
            return new PersianDateExtendedPropertyModel().FillBaseExtendedPropertyModel(dto);
        }

        public static LabelExtendedPropertyModel ToLabelExtendedPropertyModel(this ExtendedPropertyGetResultDto dto)
        {
            var extraConfig = (LabelExtendedPropertyExtraConfigDto)dto.ExtraConfig;

            return new LabelExtendedPropertyModel
            {
                // ColorId = extraConfig.ColorIndex,
                IconName = extraConfig.IconName,
                LabelText = extraConfig.LabelText,


            }.FillBaseExtendedPropertyModel(dto);
        }

        public static CrmObjectMultiValueExtendedPropertyModel ToCrmObjectMultiValueExtendedPropertyModel(this ExtendedPropertyGetResultDto dto)
        {
            var extraConfig = (CrmObjectMultiValueExtendedPropertyExtraConfigDto)dto.ExtraConfig;

            return new CrmObjectMultiValueExtendedPropertyModel
            {
                ShowInGridProps = extraConfig.VisibleProperties.Select(g => new PropertyDefinitionIdWrapperModel { Id = g.ToString() }).ToArray(),
                CrmObjectTypeIndex = extraConfig.CrmObjectType,
                SubTypeId = extraConfig.SubTypeId?.ToString(),

            }.FillBaseExtendedPropertyModel(dto);
        }

        public static TimeExtendedPropertyModel ToTimeExtendedPropertyModel(this ExtendedPropertyGetResultDto dto)
        {
            return new TimeExtendedPropertyModel().FillBaseExtendedPropertyModel(dto);
        }
        public static CurrencyExtendedPropertyModel ToCurrencyExtendedPropertyModel(this ExtendedPropertyGetResultDto dto)
        {
            var extraConfig = (CurrencyExtendedPropertyExtraConfigDto)dto.ExtraConfig;

            return new CurrencyExtendedPropertyModel
            {
                IsBalance = extraConfig.IsBalance,

            }.FillBaseExtendedPropertyModel(dto);
        }
        public static FileExtendedPropertyModel ToFileExtendedPropertyModel(this ExtendedPropertyGetResultDto dto)
        {
            var extraConfig = (FileExtendedPropertyExtraConfigDto)dto.ExtraConfig;

            return new FileExtendedPropertyModel
            {
                Extensions = extraConfig.Extensions?.ToArray(),
                MaxFileSize = extraConfig.MaxSize,
                FileSizeTypeIndex = extraConfig.FileSizeType,

            }.FillBaseExtendedPropertyModel(dto);
        }
        public static CheckboxExtendedPropertyModel ToCheckboxExtendedPropertyModel(this ExtendedPropertyGetResultDto dto)
        {
            return new CheckboxExtendedPropertyModel().FillBaseExtendedPropertyModel(dto);
        }
        public static AppointmentExtendedPropertyModel ToAppointmentExtendedPropertyModel(this ExtendedPropertyGetResultDto dto)
        {
            return new AppointmentExtendedPropertyModel().FillBaseExtendedPropertyModel(dto);
        }
        public static SecurityItemExtendedPropertyModel ToSecurityItemExtendedPropertyModel(this ExtendedPropertyGetResultDto dto)
        {
            var extraConfig = (SecurityItemExtendedPropertyExtraConfigDto)dto.ExtraConfig;

            return new SecurityItemExtendedPropertyModel
            {

            }.FillBaseExtendedPropertyModel(dto);
        }
        public static AutoNumberExtendedPropertyModel ToAutoNumberExtendedPropertyModel(this ExtendedPropertyGetResultDto dto)
        {
            var extraConfig = (AutoNumberExtendedPropertyExtraConfigDto)dto.ExtraConfig;

            return new AutoNumberExtendedPropertyModel
            {
                Prefix = extraConfig.Prefix,
                Postfix = extraConfig.Postfix,
                Seed = extraConfig.Seed,
                AutoNumLength = extraConfig.Length,

            }.FillBaseExtendedPropertyModel(dto);
        }



        public static ExtendedPropertyIdWrapperDto ToDto(this PropertyDefinitionIdWrapperModel model)
        {
            return new ExtendedPropertyIdWrapperDto { Id = Guid.Parse(model.Id) };
        }

    }
}
