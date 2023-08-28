using Septa.PayamGostarClient.Initializer.Core.APIs.Enums;
using Septa.PayamGostarClient.Initializer.Core.CrmModels;
using Septa.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeModels;
using Septa.PayamGostarClient.Initializer.Core.CrmModels.ExtendedPropertyModels;
using System;

namespace Septa.PayamGostarClient.Initializer.Test.BuildInCrmObjectModels
{
    public class EmploymentRequestModel : CrmFormModel
    {
        public const string FA_LANGUAGE_CULTURE = "fa-ir";

        public static EmploymentRequestModel Create(string languageCulture)
        {
            var newModel = new EmploymentRequestModel
            {
                Name = new[]
                {
                    new ResourceValue(){ LanguageCulture = languageCulture, Value = "درخواست جذب نیرو"},
                },
                Description = new[]
                {
                    new ResourceValue(){ LanguageCulture = languageCulture, Value = string.Empty },
                },
                Code = "EmploymentRequest",
                Enabled = true,
                PropertyGroups = new System.Collections.Generic.List<PropertyGroup>
                {
                    new PropertyGroup()
                    {
                        Name = new[]
                        {
                            new ResourceValue(){ LanguageCulture = languageCulture, Value = "اطلاعات درخواست"},
                        },
                        CountOfColumns = 2,
                        Expanded = true,
                    },
                    new PropertyGroup()
                    {
                        Name = new[]
                        {
                            new ResourceValue(){ LanguageCulture = languageCulture, Value = "اعلام نظر مدیریت"},
                        },
                        CountOfColumns = 2,
                        Expanded = false,
                    },
                    new PropertyGroup()
                    {
                        Name = new[]
                        {
                            new ResourceValue(){ LanguageCulture = languageCulture, Value = "منابع انسانی"},
                        },
                        CountOfColumns = 2,
                        Expanded = false,
                    }
                },
                Stages = new System.Collections.Generic.List<Stage>
                {
                    new Stage()
                    {
                        Name = new[]
                        {
                            new ResourceValue(){ LanguageCulture = languageCulture, Value = "درحال بررسی"},
                        },
                        IsDoneStage = false,
                        Enabled = true,
                        Key = "Processing"
                    },
                    new Stage()
                    {
                        Name = new[]
                        {
                            new ResourceValue(){ LanguageCulture = languageCulture, Value = "درحال بررسی منابع انسانی"},
                        },
                        IsDoneStage = false,
                        Enabled = true,
                        Key = "HRProcessing"
                    },
                    new Stage()
                    {
                        Name = new[]
                        {
                            new ResourceValue(){ LanguageCulture = languageCulture, Value = "تایید شده"},
                        },
                        IsDoneStage = false,
                        Enabled = true,
                        Key = "Approved"
                    },
                    new Stage()
                    {
                        Name = new[]
                        {
                            new ResourceValue(){ LanguageCulture = languageCulture, Value = "جذب شده"},
                        },
                        IsDoneStage = true,
                        Enabled = true,
                        Key = "Hired"
                    },
                    new Stage()
                    {
                        Name = new[]
                        {
                            new ResourceValue(){ LanguageCulture = languageCulture, Value = "رد شده"},
                        },
                        IsDoneStage = true,
                        Enabled = true,
                        Key = "Rejected"
                    }
                },
            };

            newModel.Properties = new System.Collections.Generic.List<BaseExtendedPropertyModel>
            {
                new UserExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = languageCulture, Value = "درخواست دهنده"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = languageCulture, Value = string.Empty},
                    },
                    PropertyGroup = newModel.PropertyGroups[0],
                    UserKey = "Applicant",
                    IsRequired = true,
                    DefaultValue = string.Empty,
                },
                new PositionExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = languageCulture, Value = "سمت شغلی مورد نیاز"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = languageCulture, Value = string.Empty},
                    },
                    PropertyGroup = newModel.PropertyGroups[0],
                    UserKey = "NeededPosition",
                    IsRequired = true,
                    DefaultValue = string.Empty,
                },
                new DepartmentExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = languageCulture, Value = "دپارتمان مربوطه"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = languageCulture, Value = string.Empty},
                    },
                    PropertyGroup = newModel.PropertyGroups[0],
                    UserKey = "HiringReqDepartment",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new DropDownListExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = languageCulture, Value = "نوع نیرو"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = languageCulture, Value = string.Empty},
                    },
                    Values = new[]
                    {
                        new DropDownListExtendedPropertyValueModel
                        {
                            Value = "نیروی جایگزین"
                        },
                        new DropDownListExtendedPropertyValueModel
                        {
                            Value = "نیروی جدید"
                        }
                    },
                    PropertyGroup = newModel.PropertyGroups[0],
                    UserKey = "ReqType",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new DropDownListExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = languageCulture, Value = "سطح نیرو" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = languageCulture, Value = string.Empty},
                    },
                    Values = new[]
                    {
                        new DropDownListExtendedPropertyValueModel()
                        {
                            Value = "Intern"
                        },
                        new DropDownListExtendedPropertyValueModel()
                        {
                            Value = "Junior"
                        },
                        new DropDownListExtendedPropertyValueModel()
                        {
                            Value = "Mid level"
                        },
                        new DropDownListExtendedPropertyValueModel()
                        {
                            Value = "Senior"
                        },
                    },
                    PropertyGroup = newModel.PropertyGroups[0],
                    UserKey = "level",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new NumberExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = languageCulture, Value = "تعداد نیرو"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = languageCulture, Value = string.Empty},
                    },
                    PropertyGroup = newModel.PropertyGroups[0],
                    UserKey = "ReqQty",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new DropDownListExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = languageCulture, Value = "اولویت درخواست"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = languageCulture, Value = string.Empty},
                    },
                    Values = new[]
                    {
                        new DropDownListExtendedPropertyValueModel()
                        {
                            Value = "بالا"
                        },
                        new DropDownListExtendedPropertyValueModel()
                        {
                            Value = "متوسط"
                        },
                        new DropDownListExtendedPropertyValueModel()
                        {
                            Value = "پایین"
                        }
                    },
                    PropertyGroup = newModel.PropertyGroups[0],
                    UserKey = "ReqPriority",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new DropDownListExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = languageCulture, Value = "جنسیت" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = languageCulture, Value = string.Empty},
                    },
                    Values = new[]
                    {
                        new DropDownListExtendedPropertyValueModel()
                        {
                            Value = "خانم"
                        },
                        new DropDownListExtendedPropertyValueModel()
                        {
                            Value = "آقا"
                        },
                        new DropDownListExtendedPropertyValueModel()
                        {
                            Value = "مهم نیست"
                        }
                    },
                    PropertyGroup = newModel.PropertyGroups[0],
                    UserKey = "Gender",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new TextExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = languageCulture, Value = "توضیحات درخواست"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = languageCulture, Value = string.Empty},
                    },
                    PropertyGroup = newModel.PropertyGroups[0],
                    UserKey = "DescriptionRequest",
                    IsRequired = false,
                    //IsMultiLine=true,
                    DefaultValue = string.Empty,
                },
                new TextExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = languageCulture, Value = "شرایط احراز شغل (دوره های آموزشی و تجارب کاری)"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = languageCulture, Value = string.Empty},
                    },
                    PropertyGroup = newModel.PropertyGroups[0],
                    UserKey = "JobConditional",
                    IsRequired = false,
                    //IsMultiLine=true,
                    DefaultValue = string.Empty,
                },
                new TextExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = languageCulture, Value = "حداقل و حداکثر حقوق پرداختی"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = languageCulture, Value = string.Empty},
                    },
                    PropertyGroup = newModel.PropertyGroups[0],
                    UserKey = "MinMaxSalary",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new TextExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = languageCulture, Value = "تجهیزات مورد نیاز"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = languageCulture, Value = string.Empty},
                    },
                    PropertyGroup = newModel.PropertyGroups[0],
                    UserKey = "NeededHardware",
                    IsRequired = false,
                    //IsMultiLine=true,
                    DefaultValue = string.Empty,
                },
                new UserExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = languageCulture, Value = "مصاحبه کننده اول"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = languageCulture, Value = string.Empty},
                    },
                    PropertyGroup = newModel.PropertyGroups[0],
                    UserKey = "FirstAssessor",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new TextExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = languageCulture, Value = "روزها و ساعات برگزاری مصاحبه" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = languageCulture, Value = string.Empty},
                    },
                    PropertyGroup = newModel.PropertyGroups[0],
                    UserKey = "InterViewDate",
                    IsRequired = false,
                    //IsMultiLine=true,
                    DefaultValue = string.Empty,
                },
                new TextExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = languageCulture, Value = "توضیحات مدیر"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = languageCulture, Value = string.Empty},
                    },
                    PropertyGroup = newModel.PropertyGroups[1],
                    UserKey = "ManagerDescription",
                    IsRequired = false,
                    //IsMultiLine=true,
                    DefaultValue = string.Empty,
                },
                new DropDownListExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = languageCulture, Value = "نیاز به مصاحبه دوم دارد؟"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = languageCulture, Value = string.Empty},
                    },
                    Values = new[]
                    {
                        new DropDownListExtendedPropertyValueModel
                        {
                            Value = "بله"
                        },
                        new DropDownListExtendedPropertyValueModel
                        {
                            Value = "خیر"
                        }
                    },
                    PropertyGroup = newModel.PropertyGroups[1],
                    UserKey = "RequiredSecondSpecialInterview",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new UserExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = languageCulture, Value = "مصاحبه کننده دوم"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = languageCulture, Value = string.Empty},
                    },
                    PropertyGroup = newModel.PropertyGroups[1],
                    UserKey = "SecondAssessor",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new UserExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = languageCulture, Value = "مسئول جذب"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = languageCulture, Value = string.Empty},
                    },
                    PropertyGroup = newModel.PropertyGroups[2],
                    UserKey = "Responsible",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new CheckboxExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = languageCulture, Value = "آگهی شده در پنل استخدامی"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = languageCulture, Value = string.Empty},
                    },
                    PropertyGroup = newModel.PropertyGroups[2],
                    UserKey = "SetInAdvertisementPanel",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new CrmObjectMultiValueExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = languageCulture, Value = "آگهی ها"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = languageCulture, Value = string.Empty},
                    },
                    PropertyGroup = newModel.PropertyGroups[2],
                    UserKey = "EmploymentRequestAds",
                    DefaultValue = string.Empty,
                    CrmObjectTypeIndex = Gp_CrmObjectType.Form,
                },
            };

            return newModel;
        }

        public static EmploymentRequestModel Create()
        {
            return Create(FA_LANGUAGE_CULTURE);
        }
    }
}
