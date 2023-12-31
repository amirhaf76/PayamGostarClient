﻿using PayamGostarClient.ApiClient.Enums;
using PayamGostarClient.Initializer.CrmModels;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;
using PayamGostarClient.Initializer.CrmModels.ExtendedPropertyModels;
using System;
using System.Collections.Generic;

namespace PayamGostarClientTest.DataTestModels.CrmFormDataTests
{
    internal static class DataTest
    {
        internal static string LANGUAGE_CULTURE { get; set; } = "fa-IR";


        internal static ResourceValue[] CreateResourceValues(params string[] names)
        {
            var resourceValues = new List<ResourceValue>();

            foreach (var name in names)
            {
                resourceValues.Add(new ResourceValue { LanguageCulture = LANGUAGE_CULTURE, Value = name });
            }

            return resourceValues.ToArray();
        }

        internal static CrmFormModel CreateAnCrmFormWithNewGeneratedCodeAndName(string nameFromat = "Auto_gen_crm_test_name_{0:N}", string codeFromat = "Auto_gen_crm_test_name_{0:N}")
        {
            var guid = Guid.NewGuid();

            nameFromat = string.Format(nameFromat, guid);
            codeFromat = string.Format(codeFromat, guid);

            return new CrmFormModel
            {
                Code = codeFromat,
                Name = CreateResourceValues(nameFromat),
            };
        }

        internal static PropertyGroup CreateASimplePropertyGroup(string nameFromat = "group", bool expand = false, int countOfColumns = 2)
        {
            var guid = Guid.NewGuid();

            nameFromat = string.Format(nameFromat, guid);

            return new PropertyGroup
            {
                Name = CreateResourceValues(nameFromat),
                CountOfColumns = countOfColumns,
                Expanded = expand,
            };
        }

        internal static Stage CreateStage(string nameFromat = "stage", string keyFormat = "stageKey", bool enable = false, bool isDoneStage = false, int index = 1)
        {
            var guid = Guid.NewGuid();

            nameFromat = string.Format(nameFromat, guid);
            keyFormat = string.Format(keyFormat, guid);

            return new Stage
            {
                Name = CreateResourceValues(nameFromat),
                Enabled = enable,
                IsDoneStage = isDoneStage,
                Key = keyFormat,
            };
        }


        internal static NumberExtendedPropertyModel CreateDefaultNumberExtendedPropertyModel(PropertyGroup group)
        {
            var property = CreateExtendedPropertyWithDefaultDto<NumberExtendedPropertyModel>(group);

            property.MinDigits = 1;
            property.MaxDigits = 3;
            property.MinValue = 1;
            property.MaxValue = 999;
            property.DecimalDigits = 2;

            return property;
        }

        internal static CheckboxExtendedPropertyModel CreateDefaultCheckBoxExtendedPropertyModel(PropertyGroup group)
        {
            var property = CreateExtendedPropertyWithDefaultDto<CheckboxExtendedPropertyModel>(group);

            return property;
        }

        internal static AppointmentExtendedPropertyModel CreateDefaultAppointmentExtendedPropertyModel(PropertyGroup group)
        {
            var property = CreateExtendedPropertyWithDefaultDto<AppointmentExtendedPropertyModel>(group);

            return property;
        }

        internal static CrmObjectMultiValueExtendedPropertyModel CreateCrmFormMultiValueExtendedPropertyModel(PropertyGroup group)
        {
            var property = CreateExtendedPropertyWithDefaultDto<CrmObjectMultiValueExtendedPropertyModel>(group);

            property.CrmObjectTypeIndex = Gp_CrmObjectType.Form;

            return property;
        }

        internal static CurrencyExtendedPropertyModel CreateDefaultCurrencyExtendedPropertyModel(PropertyGroup group)
        {
            var property = CreateExtendedPropertyWithDefaultDto<CurrencyExtendedPropertyModel>(group);

            return property;
        }

        internal static DropDownListExtendedPropertyModel CreateDefaultDropDownListExtendedPropertyModel(PropertyGroup group)
        {
            var property = CreateExtendedPropertyWithDefaultDto<DropDownListExtendedPropertyModel>(group);

            property.Values = new[]
            {
                new DropDownListExtendedPropertyValueModel { Value = "Item1" },
                new DropDownListExtendedPropertyValueModel { Value = "Item2" },
                new DropDownListExtendedPropertyValueModel { Value = "Item3" },
            };

            return property;
        }

        internal static FormExtendedPropertyModel CreateDefaultFormExtendedPropertyModel(PropertyGroup group)
        {
            var property = CreateExtendedPropertyWithDefaultDto<FormExtendedPropertyModel>(group);

            return property;
        }

        internal static FileExtendedPropertyModel CreateDefaultFileExtendedPropertyModel(PropertyGroup group)
        {
            var property = CreateExtendedPropertyWithDefaultDto<FileExtendedPropertyModel>(group);

            property.MaxFileSize = 20;
            property.FileSizeTypeIndex = FileSizeType.Megabyte;
            property.Extensions = new[] { "jpg", "png" };

            return property;
        }

        internal static UserExtendedPropertyModel CreateDefaultUserExtendedPropertyModel(PropertyGroup group)
        {
            var property = CreateExtendedPropertyWithDefaultDto<UserExtendedPropertyModel>(group);

            return property;
        }

        internal static DepartmentExtendedPropertyModel CreateDefaultDepartmentExtendedPropertyModel(PropertyGroup group)
        {
            var property = CreateExtendedPropertyWithDefaultDto<DepartmentExtendedPropertyModel>(group);

            return property;
        }

        internal static PositionExtendedPropertyModel CreateDefaultPositionExtendedPropertyModel(PropertyGroup group)
        {
            var property = CreateExtendedPropertyWithDefaultDto<PositionExtendedPropertyModel>(group);

            return property;
        }

        internal static PersianDateExtendedPropertyModel CreateDefaultPersianDateExtendedPropertyModel(PropertyGroup group)
        {
            var property = CreateExtendedPropertyWithDefaultDto<PersianDateExtendedPropertyModel>(group);

            return property;
        }

        internal static TimeExtendedPropertyModel CreateDefaultTimeExtendedPropertyModel(PropertyGroup group)
        {
            var property = CreateExtendedPropertyWithDefaultDto<TimeExtendedPropertyModel>(group);

            return property;
        }

        internal static LabelExtendedPropertyModel CreateDefaultLabelExtendedPropertyModel(PropertyGroup group)
        {
            var property = CreateExtendedPropertyWithDefaultDto<LabelExtendedPropertyModel>(group);

            property.LabelText = "label_text";

            return property;
        }

        internal static SecurityItemExtendedPropertyModel CreateDefaultSecurityItemExtendedPropertyModel(PropertyGroup group)
        {
            var property = CreateExtendedPropertyWithDefaultDto<SecurityItemExtendedPropertyModel>(group);

            return property;
        }


        internal static T CreateExtendedPropertyWithDefaultDto<T>(PropertyGroup group) where T : BaseExtendedPropertyModel, new()
        {
            return CreateExtendedPropertyWithDefaultDto<T>(x =>
            {
                x.Group = group;
            });
        }

        internal static T CreateExtendedPropertyWithDefaultDto<T>(Action<BaseExtendedPropertyDataTestDto> changeDefaultDto) where T : BaseExtendedPropertyModel, new()
        {
            var dto = BaseExtendedPropertyDataTestDto.Default;

            changeDefaultDto?.Invoke(dto);

            return new T().FillBaseExtendedPropertyModel(dto);
        }

        internal static T CreateExtendedPropertyWithDefaultDto<T>() where T : BaseExtendedPropertyModel, new()
        {
            return CreateExtendedPropertyWithDefaultDto<T>(changeDefaultDto: null);
        }

        private static T FillBaseExtendedPropertyModel<T>(this T baseModel, BaseExtendedPropertyDataTestDto dto) where T : BaseExtendedPropertyModel
        {
            var guid = Guid.NewGuid();

            var nameFromat = !string.IsNullOrEmpty(dto.NameFormat) ? string.Format(dto.NameFormat, guid) : dto.NameFormat;
            var toolTipFormat = !string.IsNullOrEmpty(dto.ToolTipFormat) ? string.Format(dto.ToolTipFormat, guid) : dto.ToolTipFormat;

            baseModel.UserKey = !string.IsNullOrEmpty(dto.UserKeyFormat) ? string.Format(dto.UserKeyFormat, guid) : dto.UserKeyFormat;

            baseModel.Name = CreateResourceValues(nameFromat);
            baseModel.ToolTip = CreateResourceValues(toolTipFormat);
            
            if (baseModel is BaseRequireableExtendedPropertyModel baseRequireableModel)
            {
                baseRequireableModel.IsRequired = dto.IsRequired;
            }

            if (baseModel is BaseSequrityExtendedPropertyModel baseSequrityModel)
            {
                baseSequrityModel.IsRequired = dto.IsRequired;
            }

            baseModel.DefaultValue = dto.DefaultValue;
            baseModel.PropertyGroup = dto.Group;

            return baseModel;
        }

    }
}
