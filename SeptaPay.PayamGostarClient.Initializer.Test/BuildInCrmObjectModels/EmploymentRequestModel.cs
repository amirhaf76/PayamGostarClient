using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Enums;
using SeptaPay.PayamGostarClient.Initializer.Core.CrmModels;
using SeptaPay.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeModels;
using SeptaPay.PayamGostarClient.Initializer.Core.CrmModels.ExtendedPropertyModels;

namespace SeptaPay.PayamGostarClient.Initializer.Test.BuildInCrmObjectModels
{
    public class EmploymentRequestModel : CrmFormModel
    {
        public const string LANGUAGE_CULTURE = "fa-ir";

        public static CrmFormModel Create()
        {
            var newModel = new CrmFormModel
            {
                Name = new[]
                {
                    new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "درخواست جذب نیرو"},
                },
                Description = new[]
                {
                    new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = string.Empty },
                },
                Code = "EmploymentRequest",
                Enabled = true,
                PropertyGroups = new System.Collections.Generic.List<PropertyGroup>
                {
                    new PropertyGroup()
                    {
                        Name = new[]
                        {
                            new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "اطلاعات درخواست"},
                        },
                        CountOfColumns = 2,
                        Expanded = true,
                    },
                    new PropertyGroup()
                    {
                        Name = new[]
                        {
                            new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "اعلام نظر مدیریت"},
                        },
                        CountOfColumns = 2,
                        Expanded = false,
                    },
                    new PropertyGroup()
                    {
                        Name = new[]
                        {
                            new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "منابع انسانی"},
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
                            new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "درحال بررسی"},
                        },
                        IsDoneStage = false,
                        Enabled = true,
                        Key = "Processing"
                    },
                    new Stage()
                    {
                        Name = new[]
                        {
                            new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "درحال بررسی منابع انسانی"},
                        },
                        IsDoneStage = false,
                        Enabled = true,
                        Key = "HRProcessing"
                    },
                    new Stage()
                    {
                        Name = new[]
                        {
                            new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "تایید شده"},
                        },
                        IsDoneStage = false,
                        Enabled = true,
                        Key = "Approved"
                    },
                    new Stage()
                    {
                        Name = new[]
                        {
                            new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "جذب شده"},
                        },
                        IsDoneStage = true,
                        Enabled = true,
                        Key = "Hired"
                    },
                    new Stage()
                    {
                        Name = new[]
                        {
                            new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "رد شده"},
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
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "درخواست دهنده"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = string.Empty},
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
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "سمت شغلی مورد نیاز"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = string.Empty},
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
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "دپارتمان مربوطه"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = string.Empty},
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
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "نوع نیرو"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = string.Empty},
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
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "سطح نیرو" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = string.Empty},
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
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "تعداد نیرو"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = string.Empty},
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
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "اولویت درخواست"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = string.Empty},
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
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "جنسیت" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = string.Empty},
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
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "توضیحات درخواست"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = string.Empty},
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
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "شرایط احراز شغل (دوره های آموزشی و تجارب کاری)"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = string.Empty},
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
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "حداقل و حداکثر حقوق پرداختی"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = string.Empty},
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
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "تجهیزات مورد نیاز"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = string.Empty},
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
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "مصاحبه کننده اول"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = string.Empty},
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
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "روزها و ساعات برگزاری مصاحبه" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = string.Empty},
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
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "توضیحات مدیر"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = string.Empty},
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
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "نیاز به مصاحبه دوم دارد؟"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = string.Empty},
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
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "مصاحبه کننده دوم"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = string.Empty},
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
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "مسئول جذب"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = string.Empty},
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
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "آگهی شده در پنل استخدامی"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = string.Empty},
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
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "آگهی ها"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = newModel.PropertyGroups[2],
                    UserKey = "EmploymentRequestAds",
                    DefaultValue = string.Empty,
                    CrmObjectTypeIndex = Gp_CrmObjectType.Form,
                },
            };

            return newModel;
        }
    }
}
