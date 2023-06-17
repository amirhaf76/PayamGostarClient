﻿using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.CrmObjectTypeModels;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.ExtendedPropertyModels;
using System;

namespace PayamGostarClientTest
{
    public class EmploymentRequestCrmFormModel : CrmFormModel
    {
        public const string LANGUAGE_CULTURE = "fa-IR";

        public static CrmFormModel Create()
        {
            var newModel = new CrmFormModel
            {
                Name = new[]
                {
                    new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "1stco- درخواست جذب نیرو (V. 1.3.2)"},
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
                        Expanded = false,
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
                            new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "IT و منابع انسانی"},
                        },
                        CountOfColumns = 2,
                        Expanded = false,
                    },
                    new PropertyGroup()
                    {
                        Name = new[]
                        {
                            new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "بلااستفاده"},
                        },
                        CountOfColumns = 1,
                        Expanded = false,
                    },
                    new PropertyGroup()
                    {
                        Name = new[]
                        {
                            new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "مرتبط با فرآیند"},
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
                            new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "تایید شده"},
                        },
                        IsDoneStage = false,
                        Enabled = true,
                    },
                    new Stage()
                    {
                        Name = new[]
                        {
                            new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "جذب شده"},
                        },
                        IsDoneStage = true,
                        Enabled = true,
                    },
                    new Stage()
                    {
                        Name = new[]
                        {
                            new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "درحال بررسی"},
                        },
                        IsDoneStage = false,
                        Enabled = true,
                    },
                    new Stage()
                    {
                        Name = new[]
                        {
                            new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "درحال بررسی منابع انسانی"},
                        },
                        IsDoneStage = false,
                        Enabled = true,
                    },
                    new Stage()
                    {
                        Name = new[]
                        {
                            new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "رد شده"},
                        },
                        IsDoneStage = true,
                        Enabled = true,
                    }
                },
            };

            newModel.Properties = new System.Collections.Generic.List<BaseExtendedPropertyModel>
            {
                new DropDownListExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "نیاز به مصاحبه تخصصی دوم؟"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = newModel.PropertyGroups[0],
                    UserKey = Guid.NewGuid().ToString(),
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new UserExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "مصاحبه کننده تخصصی اول"},
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
                new FormExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "فرم درخواست تجهیزات سخت افزاری"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = newModel.PropertyGroups[0],
                    UserKey = Guid.NewGuid().ToString(),
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new TextExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "شرایط احراز شغل( دوره های آموزشی و تجارب کاری)"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = newModel.PropertyGroups[0],
                    UserKey = Guid.NewGuid().ToString(),
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new TextExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "توضیحات نیاز به سخت افزار"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = newModel.PropertyGroups[0],
                    UserKey = Guid.NewGuid().ToString(),
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
                    PropertyGroup = newModel.PropertyGroups[0],
                    UserKey = "ReqType",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new NumberExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "Xتعداد نیرو"},
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
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "تجهیزات جدید نیاز است"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = newModel.PropertyGroups[0],
                    UserKey = Guid.NewGuid().ToString(),
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new DropDownListExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "آگهی در پنل استخدامی ثبت شد"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = newModel.PropertyGroups[2],
                    UserKey = Guid.NewGuid().ToString(),
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new TextExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "Xسمت شغلی"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = newModel.PropertyGroups[3],
                    UserKey = "XPositionasdfg",
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
                    UserKey = Guid.NewGuid().ToString(),
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new TextExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "Xتوضیحات مدیرعامل"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = newModel.PropertyGroups[4],
                    UserKey = "XTextBoxHR2",
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
                    UserKey = Guid.NewGuid().ToString(),
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new TextExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "برآورد قیمت تجهیزات مورد نیاز"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = newModel.PropertyGroups[2],
                    UserKey = Guid.NewGuid().ToString(),
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new TextExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "مدرک تحصیلی"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = newModel.PropertyGroups[0],
                    UserKey = Guid.NewGuid().ToString(),
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new UserExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "مصاحبه کننده تخصصی دوم"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = newModel.PropertyGroups[0],
                    UserKey = "SecondAssessor",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new DepartmentExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "واحد مربوطه"},
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
                    UserKey = Guid.NewGuid().ToString(),
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
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
                new UserExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "نام شرکت"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = newModel.PropertyGroups[0],
                    UserKey = "CompanyName",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new DropDownListExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "Xنام واحد"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = newModel.PropertyGroups[4],
                    UserKey = "DepName",
                    IsRequired = true,
                    DefaultValue = string.Empty,
                },
                new PersianDateExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "تاریخ پیگیری مجدد"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = newModel.PropertyGroups[2],
                    UserKey = "FollowDate",
                    IsRequired = true,
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
                    PropertyGroup = newModel.PropertyGroups[0],
                    UserKey = "ReqPriority",
                    IsRequired = false,
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
                new DropDownListExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "تجهیزات سخت افزاری برای نیروی جدید موجود است؟"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = newModel.PropertyGroups[2],
                    UserKey = Guid.NewGuid().ToString(),
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
                    IsRequired = false,
                    DefaultValue = string.Empty,
                    CrmObjectTypeIndex = Gp_CrmObjectType.Form,
                },
                new UserExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "مدیر بالادستی" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = newModel.PropertyGroups[0],
                    UserKey = Guid.NewGuid().ToString(),
                    IsRequired = true,
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
                    PropertyGroup = newModel.PropertyGroups[0],
                    UserKey = "level",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new PositionExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "سمت مدیرعامل مربوطه" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = newModel.PropertyGroups[4],
                    UserKey = "HiringReqCEO",
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
                    UserKey = Guid.NewGuid().ToString(),
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
                    PropertyGroup = newModel.PropertyGroups[0],
                    UserKey = Guid.NewGuid().ToString(),
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new TextExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "توضیحات مدیرعامل" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = newModel.PropertyGroups[1],
                    UserKey = "HireRequestCEODes",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
            };

            return newModel;
        }
    }
}