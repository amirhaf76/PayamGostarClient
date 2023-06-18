using PayamGostarClient.ApiServices.Dtos;
using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos;
using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.MultiValueExtendedProperies;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.ExtendedPropertyModels;
using System;
using System.Linq;

namespace PayamGostarClient.InitServiceModels.Extensions
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
                // IsMultiline = model.IsMultiLine,

            }.FillBaseExtendedPropertyDto(baseModel);
        }

        public static FormExtendedPropertyCreationDto ToFormExtendedPropertyCreationDto(this BaseExtendedPropertyModel baseModel)
        {
            var model = (FormExtendedPropertyModel)baseModel;

            return new FormExtendedPropertyCreationDto
            {
             
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
                SubTypeId = (model.SubTypeId != null) ? (Guid?)Guid.Parse(model.SubTypeId) : null,
                ShowInGridProps = model.ShowInGridProps?.Select(s => s.ToDto()) ?? Array.Empty<ExtendedPropertyIdWrapperDto>(),

            }.FillBaseExtendedPropertyDto(baseModel);
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


        public static ExtendedPropertyIdWrapperDto ToDto(this PropertyDefinitionIdWrapperModel model)
        {
            return new ExtendedPropertyIdWrapperDto { Id = Guid.Parse(model.Id) };
        }

    }
}
