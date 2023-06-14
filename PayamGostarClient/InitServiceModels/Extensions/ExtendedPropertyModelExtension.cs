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
                CalculationTypeIndex = model.CalculationTypeIndex,
                IsMultiline = model.IsMultiLine,

            }.FillBaseExtendedPropertyDto(baseModel);
        }

        public static FormExtendedPropertyCreationDto ToFormExtendedPropertyCreationDto(this BaseExtendedPropertyModel baseModel)
        {
            var model = (FormExtendedPropertyModel)baseModel;

            return new FormExtendedPropertyCreationDto
            {
                CrmObjectTypeId = Guid.Parse(model.CrmObjectTypeId),

            }.FillBaseExtendedPropertyDto(baseModel);
        }

        public static DropDownListExtendedPropertyCreationDto ToDropDownListExtendedPropertyCreationDto(this BaseExtendedPropertyModel baseModel)
        {
            var model = (DropDownListExtendedPropertyModel)baseModel;

            return new DropDownListExtendedPropertyCreationDto
            {
                IsRequired = model.IsRequired,
                CalculationTypeIndex = model.CalculationTypeIndex,
                CrmObjectTypeId = Guid.Parse(model.CrmObjectTypeId),

            }.FillBaseExtendedPropertyDto(baseModel);
        }

        public static UserExtendedPropertyCreationDto ToUserExtendedPropertyCreationDto(this BaseExtendedPropertyModel baseModel)
        {
            var model = (UserExtendedPropertyModel)baseModel;

            return new UserExtendedPropertyCreationDto
            {
                ShowDeactiveMembersOption = model.ShowDeactiveMembersOption,
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
                CalculationTypeIndex = model.CalculationTypeIndex,
                DecimalDigits = model.DecimalDigits,
                CrmObjectTypeId = Guid.Parse(model.CrmObjectTypeId),

            }.FillBaseExtendedPropertyDto(baseModel);
        }

        public static DepartmentExtendedPropertyCreationDto ToDepartmentExtendedPropertyCreationDto(this BaseExtendedPropertyModel baseModel)
        {
            var model = (DepartmentExtendedPropertyModel)baseModel;

            return new DepartmentExtendedPropertyCreationDto
            {
                IsRequired = model.IsRequired,
                CrmObjectTypeId = Guid.Parse(model.CrmObjectTypeId),

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
                CrmObjectTypeId = Guid.Parse(model.CrmObjectTypeId),
                CrmObjectTypeIndex = model.CrmObjectTypeIndex,
                SubTypeId = (model.SubTypeId != null) ? (Guid?)Guid.Parse(model.SubTypeId) : null,
                ShowInGridProps = model.ShowInGridProps.Select(s => s.ToDto()),

            }.FillBaseExtendedPropertyDto(baseModel);
        }

        public static ExtendedPropertyIdWrapperDto ToDto(this PropertyDefinitionIdWrapperModel model)
        {
            return new ExtendedPropertyIdWrapperDto { Id = Guid.Parse(model.Id) };
        }

    }
}
