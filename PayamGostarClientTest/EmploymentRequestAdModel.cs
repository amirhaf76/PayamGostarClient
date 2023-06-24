using PayamGostarClient.Initializer.CrmModels;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;
using PayamGostarClient.Initializer.CrmModels.ExtendedPropertyModels;
using System;

namespace PayamGostarClientTest
{
    public class EmploymentRequestAdModel : CrmFormModel
    {
        public const string LANGUAGE_CULTURE = "fa-IR";

        public static CrmFormModel Create()
        {
            var newModel = new CrmFormModel
            {
                Name = new[]
                {
                    new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "1stco- آگهی مرتبط با درخواست جذب نیرو"},
                },
                Description = new[]
                {
                    new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = string.Empty },
                },
                Code = "EmploymentRequestAd",
                Enabled = true,
                PropertyGroups = new System.Collections.Generic.List<PropertyGroup>
                {
                    new PropertyGroup()
                    {
                        Name = new[]
                        {
                            new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "اطلاعات محل انتشار"},
                        },
                        CountOfColumns = 1,
                        Expanded = false,
                    }
                },
            };

            newModel.Properties = new System.Collections.Generic.List<BaseExtendedPropertyModel>
            {
                new NumberExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "تعداد رزومه دریافتی"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = newModel.PropertyGroups[0],
                    UserKey = "TotalResumeCount",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new TextExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value =  "عنوان آگهی"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = newModel.PropertyGroups[0],
                    UserKey = "JobPostTitle",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new TextExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "کد آگهی"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = newModel.PropertyGroups[0],
                    UserKey = "JobPostId",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new TextExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "منبع انتشار آگهی"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = newModel.PropertyGroups[0],
                    UserKey = "Source",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new PersianDateExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "تاریخ آخرین غربالگری"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = newModel.PropertyGroups[0],
                    UserKey = "LastFilterDate",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },

            };

            return newModel;
        }
    }
}
