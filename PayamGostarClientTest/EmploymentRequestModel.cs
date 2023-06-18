using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.CrmObjectTypeModels;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.ExtendedPropertyModels;
using System;

namespace PayamGostarClientTest
{
    public class EmploymentRequestModel : CrmFormModel
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
                        Index = 3,
                    },
                    new Stage()
                    {
                        Name = new[]
                        {
                            new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "جذب شده"},
                        },
                        IsDoneStage = true,
                        Enabled = true,
                        Index = 4
                    },
                    new Stage()
                    {
                        Name = new[]
                        {
                            new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "درحال بررسی"},
                        },
                        IsDoneStage = false,
                        Enabled = true,
                        Index = 1
                    },
                    new Stage()
                    {
                        Name = new[]
                        {
                            new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "درحال بررسی منابع انسانی"},
                        },
                        IsDoneStage = false,
                        Enabled = true,
                        Index = 2,
                    },
                    new Stage()
                    {
                        Name = new[]
                        {
                            new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "رد شده"},
                        },
                        IsDoneStage = true,
                        Enabled = true,
                        Index = 5
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
                    Values = new[]
                    {
                        new DropDownListExtendedPropertyValueModel
                        {
                            Value = "دارد"
                        },
                        new DropDownListExtendedPropertyValueModel
                        {
                            Value = "ندارد"
                        }
                    },
                    PropertyGroup = newModel.PropertyGroups[0],
                    UserKey = "RequiredSecondSpecialInterview",
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
                    UserKey = "RequiredFormHardware",
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
                    UserKey = "JobConditional",
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
                    UserKey = "HardwareRequiredDescription",
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
                    Values = new[]
                    {
                        new DropDownListExtendedPropertyValueModel
                        {
                            Value = "بلی"
                        },
                        new DropDownListExtendedPropertyValueModel
                        {
                            Value = "خیر"
                        }
                    },
                    PropertyGroup = newModel.PropertyGroups[0],
                    UserKey = "IsRequiredNewAdditionalHardware",
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
                    Values = new[]
                    {
                        new DropDownListExtendedPropertyValueModel
                        {
                            Value = "بله"
                        }
                    },
                    PropertyGroup = newModel.PropertyGroups[2],
                    UserKey = "SetInAdvertisementPanel",
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
                    UserKey = "NeededHardware",
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
                    UserKey = "DescriptionRequest",
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
                    UserKey = "CalculatedHardwaresPrice",
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
                    UserKey = "Diploma",
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
                    UserKey = "MinMaxSalary",
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
                new DropDownListExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = "نام شرکت"},
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    Values = new[]
                    {
                        new DropDownListExtendedPropertyValueModel
                        {
                            Value = "شرکت پیام گستر"
                        },
                        new DropDownListExtendedPropertyValueModel
                        {
                            Value = "شرکت الوویپ"
                        },
                        new DropDownListExtendedPropertyValueModel
                        {
                            Value = "هلدینگ تجارت الکترونیک اول"
                        },
                        new DropDownListExtendedPropertyValueModel
                        {
                            Value = "شرکت هیتوبیت"
                        },
                        new DropDownListExtendedPropertyValueModel
                        {
                            Value = "شرکت تجارت اول"
                        },
                        new DropDownListExtendedPropertyValueModel
                        {
                            Value = "شرکت سپتا پرداخت"
                        }
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
                    Values = new[]
                    {
                        new DropDownListExtendedPropertyValueModel() { Value = "تجارت اول" },
                        new DropDownListExtendedPropertyValueModel() { Value = "امور مشتریان" },
                        new DropDownListExtendedPropertyValueModel() { Value = "امور نمایندگان" },
                        new DropDownListExtendedPropertyValueModel() { Value = "فروش پیام گستر" },
                        new DropDownListExtendedPropertyValueModel() { Value = "فروش تکمیلی پیام گستر" },
                        new DropDownListExtendedPropertyValueModel() { Value = "مارکتینگ" },
                        new DropDownListExtendedPropertyValueModel() { Value = "مالی" },
                        new DropDownListExtendedPropertyValueModel() { Value = "منابع انسانی" },
                        new DropDownListExtendedPropertyValueModel() { Value = "فروش ویپ" },
                        new DropDownListExtendedPropertyValueModel() { Value = "پشتیبانی ویپ" },
                        new DropDownListExtendedPropertyValueModel() { Value = "فنی" },
                        new DropDownListExtendedPropertyValueModel() { Value = "محصول" },
                        new DropDownListExtendedPropertyValueModel() { Value = "پشتیبانی پیام گستر" },
                        new DropDownListExtendedPropertyValueModel() { Value = "نصب پیام گستر" },
                        new DropDownListExtendedPropertyValueModel() { Value = "IT" },
                        new DropDownListExtendedPropertyValueModel() { Value = "استقرار و آموزش" },
                        new DropDownListExtendedPropertyValueModel() { Value = "سیستم و روش ها" },
                        new DropDownListExtendedPropertyValueModel() { Value = "سپتا" },
                        new DropDownListExtendedPropertyValueModel() { Value = "اداری" },
                        new DropDownListExtendedPropertyValueModel() { Value = "مارکتینگ هیتوبیت" },
                        new DropDownListExtendedPropertyValueModel() { Value = "موفقیت مشتری هیتوبیت" },
                    },
                    PropertyGroup = newModel.PropertyGroups[4],
                    UserKey = "DepName",
                    IsRequired = false,
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
                    Values = new[]
                    {
                        new DropDownListExtendedPropertyValueModel()
                        {
                            Value = "بله"
                        },
                        new DropDownListExtendedPropertyValueModel()
                        {
                            Value = "خیر"
                        },
                    },
                    PropertyGroup = newModel.PropertyGroups[2],
                    UserKey = "IsSystemAvailable",
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
                    UserKey = "EmploymentRequestAd",
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
                    UserKey = "Superviser",
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
                    Values = new[]
                    {
                        new DropDownListExtendedPropertyValueModel()
                        {
                            Value = "junior"
                        },
                        new DropDownListExtendedPropertyValueModel()
                        {
                            Value = "mid level"
                        },
                        new DropDownListExtendedPropertyValueModel()
                        {
                            Value = "senior"
                        },
                        new DropDownListExtendedPropertyValueModel()
                        {
                            Value = "کارآموز"
                        }
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
                    UserKey = "InterViewDate",
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
