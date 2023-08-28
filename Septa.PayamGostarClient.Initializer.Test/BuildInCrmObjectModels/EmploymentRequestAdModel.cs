using Septa.PayamGostarClient.Initializer.Core.CrmModels;
using Septa.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeModels;
using Septa.PayamGostarClient.Initializer.Core.CrmModels.ExtendedPropertyModels;

namespace Septa.PayamGostarClient.Initializer.Test.BuildInCrmObjectModels
{
    public class EmploymentRequestAdModel : CrmFormModel
    {
        public const string FA_LANGUAGE_CULTURE = "fa-ir";

        public static EmploymentRequestAdModel Create(string languageCulture)
        {
            var newModel = new EmploymentRequestAdModel
            {
                Name = new[]
                {
                    new ResourceValue(){ LanguageCulture = languageCulture, Value = "آگهی مرتبط با درخواست جذب نیرو"},
                },
                Description = new[]
                {
                    new ResourceValue(){ LanguageCulture = languageCulture, Value = string.Empty },
                },
                Code = "EmploymentRequestAd",
                Enabled = true,
                PropertyGroups = new System.Collections.Generic.List<PropertyGroup>
                {
                    new PropertyGroup()
                    {
                        Name = new[]
                        {
                            new ResourceValue(){ LanguageCulture = languageCulture, Value = "اطلاعات آگهی"},
                        },
                        CountOfColumns = 2,
                        Expanded = true,
                    }
                },
            };

            newModel.Properties = new System.Collections.Generic.List<BaseExtendedPropertyModel>
            {
                new TextExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = languageCulture, Value =  "عنوان آگهی"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = languageCulture, Value = string.Empty},
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
                        new ResourceValue(){ LanguageCulture = languageCulture, Value = "کد"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = languageCulture, Value = string.Empty},
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
                        new ResourceValue(){ LanguageCulture = languageCulture, Value = "منبع انتشار"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = languageCulture, Value = string.Empty},
                    },
                    PropertyGroup = newModel.PropertyGroups[0],
                    UserKey = "Source",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new NumberExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = languageCulture, Value = "تعداد رزومه دریافتی"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = languageCulture, Value = string.Empty},
                    },
                    PropertyGroup = newModel.PropertyGroups[0],
                    UserKey = "TotalResumeCount",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new PersianDateExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = languageCulture, Value = "تاریخ آخرین غربال"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = languageCulture, Value = string.Empty},
                    },
                    PropertyGroup = newModel.PropertyGroups[0],
                    UserKey = "LastFilterDate",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },

            };

            return newModel;
        }

        public static EmploymentRequestAdModel Create()
        {
            return Create(FA_LANGUAGE_CULTURE);
        }
    }
}
