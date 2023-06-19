using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.CrmObjectTypeModels;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.ExtendedPropertyModels;
using System;

namespace PayamGostarClientTest
{
    public class InterviewTicketModel
    {
        public const string FA_LANGUAGE_CULTURE = "fa-IR";

        public static CrmTicketModel Create()
        {
            var model = new CrmTicketModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { LanguageCulture = FA_LANGUAGE_CULTURE,  Value = "1stco- مصاحبه (V. 1.4.2)",},
                },
                Description = new ResourceValue[]
                {
                    new ResourceValue { LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty },
                },
                Code = $"interview",
                ResponseTemplate = "",
                ListenLineId = Guid.Parse("eb7fbe77-37b2-4ac7-95d4-96f09d5bafbe"), // payamgostarst@gmail.com
                Enabled = true,
                PreviewTypeIndex = Gp_PreviewType.WordPreview,
                PropertyGroups = new System.Collections.Generic.List<PropertyGroup>
                {
                    new PropertyGroup()
                    {
                        Name = new[]
                        {
                            new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "هماهنگی مصاحبه اول"},
                        },
                        CountOfColumns = 2,
                        Expanded = false,
                    },
                    new PropertyGroup()
                    {
                        Name = new[]
                        {
                            new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "هماهنگی مصاحبه دوم"},
                        },
                        CountOfColumns = 2,
                        Expanded = false,
                    },
                    new PropertyGroup()
                    {
                        Name = new[]
                        {
                            new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "هماهنگی مصاحبه منابع انسانی"},
                        },
                        CountOfColumns = 2,
                        Expanded = false,
                    },
                    new PropertyGroup()
                    {
                        Name = new[]
                        {
                            new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "اطلاعات مصاحبه"},
                        },
                        CountOfColumns = 2,
                        Expanded = false,
                    },
                    new PropertyGroup()
                    {
                        Name = new[]
                        {
                            new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "اطلاعات متقاضی"},
                        },
                        CountOfColumns = 2,
                        Expanded = false,
                    },
                    new PropertyGroup()
                    {
                        Name = new[]
                        {
                            new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "بلااستفاده"},
                        },
                        CountOfColumns = 2,
                        Expanded = false,
                    },
                    new PropertyGroup()
                    {
                        Name = new[]
                        {
                            new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "مرتبط با فرآیند"},
                        },
                        CountOfColumns = 2,
                        Expanded = false,
                    },
                },
                Stages = new System.Collections.Generic.List<Stage>
                {
                    new Stage()
                    {
                        Name = new[]
                        {
                            new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "غربالگری"},
                        },
                        IsDoneStage = false,
                        Enabled = true,
                        Index = 1,

                    },
                    new Stage()
                    {
                        Name = new[]
                        {
                            new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "هماهنگی  اول"},
                        },
                        IsDoneStage = false,
                        Enabled = true,
                        Index = 2,

                    },
                    new Stage()
                    {
                        Name = new[]
                        {
                            new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "مصاحبه اول"},
                        },
                        IsDoneStage = false,
                        Enabled = true,
                        Index = 3,
                    },
                    new Stage()
                    {
                        Name = new[]
                        {
                            new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "هماهنگی دوم"},
                        },
                        IsDoneStage = false,
                        Enabled = true,
                        Index = 4,
                    },
                    new Stage()
                    {
                        Name = new[]
                        {
                            new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "مصاحبه دوم"},
                        },
                        IsDoneStage = false,
                        Enabled = true,
                        Index = 5,
                    },
                    new Stage()
                    {
                        Name = new[]
                        {
                            new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "هماهنگی مصاحبه منابع انسانی"},
                        },
                        IsDoneStage = false,
                        Enabled = true,
                        Index = 6,
                    },
                    new Stage()
                    {
                        Name = new[]
                        {
                            new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "مصاحبه منابع انسانی"},
                        },
                        IsDoneStage = false,
                        Enabled = true,
                        Index = 7,
                    },
                    new Stage()
                    {
                        Name = new[]
                        {
                            new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "جذب شده"},
                        },
                        IsDoneStage = true,
                        Enabled = true,
                        Index = 8,
                    },
                    new Stage()
                    {
                        Name = new[]
                        {
                            new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "رد شده"},
                        },
                        IsDoneStage = true,
                        Enabled = true,
                        Index = 9,
                    },
                },

                PriorityMatrix = new PriorityMatrixModel
                {
                    Details = new[]
                   {
                        new PriorityMatrixDetailModel
                        {
                            ImpactIndex = Gp_Matrix_Impact.Little,
                            SeverityIndex = Gp_Matrix_Severity.Low,
                            PriorityIndex = Gp_Matrix_Priority.Low,
                        },
                        new PriorityMatrixDetailModel
                        {
                            ImpactIndex = Gp_Matrix_Impact.Little,
                            SeverityIndex = Gp_Matrix_Severity.Middle,
                            PriorityIndex = Gp_Matrix_Priority.Middle,
                        },
                        new PriorityMatrixDetailModel
                        {
                            ImpactIndex = Gp_Matrix_Impact.Little,
                            SeverityIndex = Gp_Matrix_Severity.Critical,
                            PriorityIndex = Gp_Matrix_Priority.Middle,
                        },
                        new PriorityMatrixDetailModel
                        {
                            ImpactIndex = Gp_Matrix_Impact.Seriously,
                            SeverityIndex = Gp_Matrix_Severity.Low,
                            PriorityIndex = Gp_Matrix_Priority.Low,
                        },
                        new PriorityMatrixDetailModel
                        {
                            ImpactIndex = Gp_Matrix_Impact.Seriously,
                            SeverityIndex = Gp_Matrix_Severity.Middle,
                            PriorityIndex = Gp_Matrix_Priority.High,
                        },
                        new PriorityMatrixDetailModel
                        {
                            ImpactIndex = Gp_Matrix_Impact.Seriously,
                            SeverityIndex = Gp_Matrix_Severity.Critical,
                            PriorityIndex = Gp_Matrix_Priority.High,
                        },
                        new PriorityMatrixDetailModel
                        {
                            ImpactIndex = Gp_Matrix_Impact.Disastrous,
                            SeverityIndex = Gp_Matrix_Severity.Low,
                            PriorityIndex = Gp_Matrix_Priority.Middle,
                        },
                        new PriorityMatrixDetailModel
                        {
                            ImpactIndex = Gp_Matrix_Impact.Disastrous,
                            SeverityIndex = Gp_Matrix_Severity.Middle,
                            PriorityIndex = Gp_Matrix_Priority.High,
                        },
                        new PriorityMatrixDetailModel
                        {
                            ImpactIndex = Gp_Matrix_Impact.Disastrous,
                            SeverityIndex = Gp_Matrix_Severity.Critical,
                            PriorityIndex = Gp_Matrix_Priority.High,
                        },
                    }
                }
            };

            model.Properties = new System.Collections.Generic.List<BaseExtendedPropertyModel>
            {
                new DropDownListExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "نام شرکت" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    Values = new DropDownListExtendedPropertyValueModel[]
                    {
                         new DropDownListExtendedPropertyValueModel{  Value = "شرکت الوویپ" },
                         new DropDownListExtendedPropertyValueModel{  Value = "هلدینگ تجارت الکترونیک اول" },
                         new DropDownListExtendedPropertyValueModel{  Value = "شرکت سپتا پرداخت" },
                         new DropDownListExtendedPropertyValueModel{  Value = "شرکت هیتوبیت" },
                         new DropDownListExtendedPropertyValueModel{  Value = "شرکت تجارت اول" },
                    },
                    PropertyGroup = model.PropertyGroups[0],
                    UserKey = "CompanyName",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new DropDownListExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "Xروز مصاحبه منابع انسانی" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    Values = new DropDownListExtendedPropertyValueModel[]
                    {
                         new DropDownListExtendedPropertyValueModel{  Value = "شنبه" },
                         new DropDownListExtendedPropertyValueModel{  Value = "یکشنبه" },
                         new DropDownListExtendedPropertyValueModel{  Value = "دوشنبه" },
                         new DropDownListExtendedPropertyValueModel{  Value = "سه شنبه" },
                         new DropDownListExtendedPropertyValueModel{  Value = "چهارشنبه" },
                         new DropDownListExtendedPropertyValueModel{  Value = "پنجشنبه" },
                    },
                    PropertyGroup = model.PropertyGroups[0],
                    UserKey = "XDayOfWeekHR",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new DropDownListExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "دلیل رد در هماهنگی مصاحبه" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    Values = new DropDownListExtendedPropertyValueModel[]
                    {
                         new DropDownListExtendedPropertyValueModel { Value = " پر شدن موقعیت شغلی" },
                         new DropDownListExtendedPropertyValueModel { Value = "مشغول شدن در شرکت دیگر" },
                         new DropDownListExtendedPropertyValueModel { Value = "دور بودن مسافت از محل زندگی تا شرکت" },
                         new DropDownListExtendedPropertyValueModel { Value = "عدم برقراری ارتباط" },
                         new DropDownListExtendedPropertyValueModel { Value = "هرزنامه" },
                         new DropDownListExtendedPropertyValueModel { Value = "فرم تکراری" },
                         new DropDownListExtendedPropertyValueModel { Value = "حقوق درخواستی بین 10 تا 14 میلیون" },
                         new DropDownListExtendedPropertyValueModel { Value = "حقوق درخواستی بین 15 تا 19 میلیون" },
                         new DropDownListExtendedPropertyValueModel { Value = "حقوق درخواستی از 20 میلیون به بالا" },
                         new DropDownListExtendedPropertyValueModel { Value = "تمایل به دورکاری کامل" },
                         new DropDownListExtendedPropertyValueModel { Value = "تمایل به کار هیبریدی" },
                         new DropDownListExtendedPropertyValueModel { Value = "تمایل به کار پاره‌وقت/پروژه‌ای" },
                         new DropDownListExtendedPropertyValueModel { Value = "انصراف از درخواست کار" },
                         new DropDownListExtendedPropertyValueModel { Value = "انصراف از ادامه مراحل استخدام" },
                         new DropDownListExtendedPropertyValueModel { Value = "عدم تطابق با شایستگی های رفتاری شغل" },
                    },
                    PropertyGroup = model.PropertyGroups[0],
                    UserKey = "CoordinationRejectReason",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new DropDownListExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "دلیل رد در غربالگری" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    Values = new DropDownListExtendedPropertyValueModel[]
                    {
                         new DropDownListExtendedPropertyValueModel{ Value = "پر شدن موقعیت شغلی" },
                         new DropDownListExtendedPropertyValueModel{ Value = "دور بودن مسافت محل زندگی از شرکت" },
                         new DropDownListExtendedPropertyValueModel{ Value = "فراتر از حد انتظار بودن" },
                         new DropDownListExtendedPropertyValueModel{ Value = "فرم تکراری" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کافی نبودن دانش فنی" },
                         new DropDownListExtendedPropertyValueModel{ Value = "نامرتبط بودن تجربیات" },
                         new DropDownListExtendedPropertyValueModel{ Value = "عدم تطابق رشته تحصیلی/سطح تحصیلی" },
                         new DropDownListExtendedPropertyValueModel{ Value = "غربال اشتباه کارشناس" },
                         new DropDownListExtendedPropertyValueModel{ Value = "بالا بودن حقوق درخواستی" },
                         new DropDownListExtendedPropertyValueModel{ Value = "عدم تطابق سنی" },
                         new DropDownListExtendedPropertyValueModel{ Value = "سایر موارد" },
                    },
                    PropertyGroup = model.PropertyGroups[0],
                    UserKey = "FilteringRejectCause",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new DropDownListExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "Xعنوان آگهی" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    Values = new DropDownListExtendedPropertyValueModel[]
                    {
                         new DropDownListExtendedPropertyValueModel{ Value = "UI Designer (آقا)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "طراح گرافیک" },
                         new DropDownListExtendedPropertyValueModel{ Value = "مدیر محصول" },
                         new DropDownListExtendedPropertyValueModel{ Value = "طراح وب UI/UX (آقا)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس امور مشتریان" },
                         new DropDownListExtendedPropertyValueModel{ Value = "برنامه‌نویس NET." },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس جذب و استخدام" },
                         new DropDownListExtendedPropertyValueModel{ Value = "HR Manager" },
                         new DropDownListExtendedPropertyValueModel{ Value = "مدیر امور نمایندگان" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارآموز IT (آقا)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارمند اداری (خانم)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "Back-End Developer" },
                         new DropDownListExtendedPropertyValueModel{ Value = "\tFront-End Developer" },
                         new DropDownListExtendedPropertyValueModel{ Value = "مدیر فنی برنامه‌نویسی (CTO)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "مدیر مالی" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس فروش(خانم)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس مالی (آقا)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "مسئول دفتر (خانم)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس تولید محتوا" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس تبلیغات دیجیتال" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس تست نرم افزار" },
                         new DropDownListExtendedPropertyValueModel{ Value = "عکاس" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس نصب نرم‌افزار" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارمند فروش (خانم)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس منابع انسانی" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس مالی" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس SEO" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس فنی VOIP" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس پشتیبانی (خانم)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "مدیر تبلیغات" },
                         new DropDownListExtendedPropertyValueModel{ Value = "مدیر فروش نرم افزار" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس ارشد فروش نرم افزار (آقا)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "حسابدار" },
                         new DropDownListExtendedPropertyValueModel{ Value = "React Native Developer" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس استقرار نرم افزار" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس سیستم‌ها و روش‌ها" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس ارشد فروش Voip (آقا)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "مدیر فنی Voip" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس استقرار CRM" },
                         new DropDownListExtendedPropertyValueModel{ Value = "تحصیلدار" },
                         new DropDownListExtendedPropertyValueModel{ Value = "Junior .net Developer" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس تحلیل و طراحی نرم افزار" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس دیجیتال مارکتینگ" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس QA" },
                         new DropDownListExtendedPropertyValueModel{ Value = "Web Designer" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارآموز برنامه‌نویسی NET." },
                         new DropDownListExtendedPropertyValueModel{ Value = "(Product Designer (UI/UX" },
                         new DropDownListExtendedPropertyValueModel{ Value = "Senior .NET Developer" },
                         new DropDownListExtendedPropertyValueModel{ Value = "برنامه‌نویس (Front-End (ReactJS" },
                         new DropDownListExtendedPropertyValueModel{ Value = "مدیر مارکتینگ (CMO)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس فروش امور نمایندگان(خانم)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس فروش نرم افزار(خانم)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس ارشد فروش (آقا)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "برنامه نویس React JS" },
                         new DropDownListExtendedPropertyValueModel{ Value = " برنامه نویس React Native" },
                         new DropDownListExtendedPropertyValueModel{ Value = "برنامه‌نویس Net Core." },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارآموز SEO" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس پشتیبانی نرم افزار (CRM-خانم)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس روابط عمومی" },
                         new DropDownListExtendedPropertyValueModel{ Value = "مدیر IT(آقا)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "طراح و گرافیست" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس حسابداری مالی" },
                         new DropDownListExtendedPropertyValueModel{ Value = "برنامه نویس #C" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس پشتیبانی نرم افزار (CRM) - خانم" },
                         new DropDownListExtendedPropertyValueModel{ Value = "برنامه‌ نویس NET." },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس شبکه های اجتماعی (Social Media-خانم)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "دستیار مدیرعامل" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس پشتیبانی فنی نرم افزار (SQL)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "مسئول دفتر مدیرعامل (خانم)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "Full-Stack Developer" },
                         new DropDownListExtendedPropertyValueModel{ Value = " مسئول دفتر مدیرعامل - خانم" },
                         new DropDownListExtendedPropertyValueModel{ Value = "مدیر ارشد دیجیتال مارکتینگ" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس پشتیبانی - خانم" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارمند اداری پذیرش(آقا)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارمند اداری پذیرش - آقا" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارمند پذیرش(آقا)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس تست نرم افزار QA" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس سئو" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس مستندساز نرم‌افزار" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس شبکه‌های اجتماعی" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس تست نرم‌افزار QA" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارآموز جذب و استخدام" },
                         new DropDownListExtendedPropertyValueModel{ Value = "دستیار مدیر محصول" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس ارشد IT(آقا)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس ارشد فروش - آقا" },
                         new DropDownListExtendedPropertyValueModel{ Value = "مسئول دفتر - خانم" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارمند امور مشتریان(خانم)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس مستندساز" },
                         new DropDownListExtendedPropertyValueModel{ Value = "بازاریاب حضوری" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس فروش نرم افزار - خانم" },
                         new DropDownListExtendedPropertyValueModel{ Value = "طراح وب UI/UX" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس امور نمایندگان" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس معرفی محصول" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارمند فروش خانم" },
                         new DropDownListExtendedPropertyValueModel{ Value = "طراح وب" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس ارشد مذاکره" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس فنی ویپ" },
                         new DropDownListExtendedPropertyValueModel{ Value = "مدیر بازاریابی" },
                         new DropDownListExtendedPropertyValueModel{ Value = "مدیر توسعه محصول" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس حسابدار مالیاتی" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارآموز حسابداری" },
                         new DropDownListExtendedPropertyValueModel{ Value = "مهندس کامپیوتر" },
                         new DropDownListExtendedPropertyValueModel{ Value = "مهندس کامپیوتر (نرم‌افزار-خانم)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس پشتیبانی نرم افزار (CRM)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس استقرار نرم‌افزار" },
                         new DropDownListExtendedPropertyValueModel{ Value = "نگهبان شیفت شب - آقا" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس برنامه‌ریزی" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارآموز هوش تجاری (BI)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس اسکرام مستر" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس پشتیبانی فنی نرم‌افزار (SQL)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "خدمات و آبدارچی" },
                         new DropDownListExtendedPropertyValueModel{ Value = "مدیر دیجیتال مارکتینگ" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس ارشد فروش نرم افزار - آقا" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس آموزش" },
                         new DropDownListExtendedPropertyValueModel{ Value = "برنامه‌نویس ReactJS" },
                         new DropDownListExtendedPropertyValueModel{ Value = "مدیر تیم برنامه نویسی(CTO)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "مدیر پشتیبانی فنی(Voip-آقا)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "طراح ارشد تجربه کاربری (Senior UX Designer)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس ارشد فروش نرم افزار" },
                         new DropDownListExtendedPropertyValueModel{ Value = "مهندس صنایع" },
                         new DropDownListExtendedPropertyValueModel{ Value = "برنامه‌نویس ارشد React) Front-End)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "مالک محصول (Product Owner)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس پشتیبانیVOIP (آقا)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس هوش تجاری (BI)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "مدیر فروش (سخت افزار-Voip)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارآموز شبکه های اجتماعی" },
                         new DropDownListExtendedPropertyValueModel{ Value = "مدیر فنی برنامه نویسی (CTO)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس منابع انسانی(خانم)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "برنامه‌نویس C#.Net" },
                         new DropDownListExtendedPropertyValueModel{ Value = "Account Manager" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس فروش - خانم" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس منابع انسانی - خانم" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارآموز جذب و استخدام(خانم)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارآموز فنی ویپ (آقا)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "برنامه نویس ارشد Net Core." },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس حسابرسی داخلی" },
                         new DropDownListExtendedPropertyValueModel{ Value = "Senior Asp.net Developer" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارمند خدمات - آقا" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس شبکه‌ های اجتماعی (Social Media)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس گوگل ادز (Google Ads)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس امور اداری" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس امور اداری و منابع انسانی" },
                         new DropDownListExtendedPropertyValueModel{ Value = "رییس حسابداری" },
                         new DropDownListExtendedPropertyValueModel{ Value = "رئیس حسابداری" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس فروش تلفنی(خانم)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس فروش تلفنی (خانم)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارآموز پشتیبانی" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارآموز تست نرم افزار (QA)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارآموز فروش" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارآموز امور مشتریان" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس فروش تلفنی" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس پشتیبانی شبکه" },
                         new DropDownListExtendedPropertyValueModel{ Value = "موشن گرافیست" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کپی رایتر (Copywriter)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "Front-End Web Developer" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس ارشد فروش (نرم افزار)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "React) Junior Front-End Developer)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "Performance Marketing Expert" },
                         new DropDownListExtendedPropertyValueModel{ Value = "Brand Expert" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس فروش نرم افزار (آقا)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس فروش (آقا)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس مهندسی صنایع" },
                         new DropDownListExtendedPropertyValueModel{ Value = "طراح سایت (Wordpress)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "سرپرست منابع انسانی" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس فروش سازمانی (B2B-آقا)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "مدیر فروش نرم افزار(آقا)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس ارشد مذاکرات (آقا)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "PR Expert" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارآموز نصب نرم افزار" },
                         new DropDownListExtendedPropertyValueModel{ Value = "سرپرست حسابداری" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس منابع انسانی و اداری" },
                         new DropDownListExtendedPropertyValueModel{ Value = "مدیر برند" },
                         new DropDownListExtendedPropertyValueModel{ Value = "سرپرست دیجیتال مارکتینگ" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس پشتیبانی نرم‌افزار" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس پشتیبانی نرم افزار" },
                         new DropDownListExtendedPropertyValueModel{ Value = "برنامه‌نویسJunior .Net Core" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس ارشد مالی" },
                         new DropDownListExtendedPropertyValueModel{ Value = "Technical Writer" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس مستندساز" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس پشتیبانی شبکه" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس تست نرم‌افزار (QA)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس حسابداری مالی" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارمند اداری" },
                         new DropDownListExtendedPropertyValueModel{ Value = "مدیر مارکتینگ" },
                         new DropDownListExtendedPropertyValueModel{ Value = "HR Generalist" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس تحلیل داده و هوش تجاری" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس ارشد تحلیل داده و هوش تجاری" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس ارتباط با مشتری(خانم)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس حسابداری مالی" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارآموز فنی ویپ" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارآموز IT" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس فنی Voip" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس ارتباط با مشتریان - خانم" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس ارشد مالی" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس مالی (حسابدار)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس ارشد حسابداری" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس فروش نرم‌افزار ویپ" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس فروش" },
                         new DropDownListExtendedPropertyValueModel{ Value = "مهندس کامپیوتر (نرم افزار) - خانم" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس فروش-خانم" },
                         new DropDownListExtendedPropertyValueModel{ Value = "استخدام کارشناس فروش (خانم)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "مدیر منابع انسانی" },
                         new DropDownListExtendedPropertyValueModel{ Value = "برنامه‌نویس #C" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس فروش نرم افزار" },
                         new DropDownListExtendedPropertyValueModel{ Value = "مدیر پشتیبانی فنی (Voip-آقا)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "سرپرست تیم فنی (Voip-آقا)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس موفقیت مشتری" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارآموز فروش" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس ارتباط با مشتریان(خانم)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارآموز برنامه نویسی NET." },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارآموز تحلیل داده و هوش تجاری" },
                         new DropDownListExtendedPropertyValueModel{ Value = "Backend Developer" },
                         new DropDownListExtendedPropertyValueModel{ Value = "برنامه‌نویس Front-End" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس ارتباط با مشتری (خانم)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "Front-End Developer" },
                         new DropDownListExtendedPropertyValueModel{ Value = "برنامه‌نویس HTML/CSS (مسلط به وردپرس)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس ارشد فروش (مذاکره)" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس سیستم‌ها و روش‌ها" },
                         new DropDownListExtendedPropertyValueModel{ Value = "برنامه‌نویس Wordpress" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس صنایع" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس برنامه ریزی و کنترل پروژه" },
                         new DropDownListExtendedPropertyValueModel{ Value = "سرپرست تیم فنی (Voip) - آقا" },
                         new DropDownListExtendedPropertyValueModel{ Value = "برنامه‌نویس ارشد Back-End" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس برنامه‌ریزی و کنترل پروژه" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس ارشد فنی ویپ" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس بازاریابی محتوا" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس بازاریابی شبکه‌های اجتماعی" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس دیجیتال مارکتینگ" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس ارشد جذب و استخدام" },
                         new DropDownListExtendedPropertyValueModel{ Value = "کارشناس طراحی گرافیک" },
                         new DropDownListExtendedPropertyValueModel{ Value = "Digital Marketing Supervisor" },
                         new DropDownListExtendedPropertyValueModel{ Value = "Graphic Designer Expert" },
                         new DropDownListExtendedPropertyValueModel{ Value = "Social Media Marketing Expert" },
                         new DropDownListExtendedPropertyValueModel{ Value = "Content Marketing Expert" },
                    },
                    PropertyGroup = model.PropertyGroups[0],
                    UserKey = "XTitle",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new DropDownListExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "Xروز مصاحبه دوم" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    Values = new DropDownListExtendedPropertyValueModel[]
                    {
                        new DropDownListExtendedPropertyValueModel{ Value = "شنبه" },
                        new DropDownListExtendedPropertyValueModel{ Value = "یکشنبه" },
                        new DropDownListExtendedPropertyValueModel{ Value = "دوشنبه" },
                        new DropDownListExtendedPropertyValueModel{ Value = "سه شنبه" },
                        new DropDownListExtendedPropertyValueModel{ Value = "چهارشنبه" },
                        new DropDownListExtendedPropertyValueModel{ Value = "پنجشنبه" },
                    },
                    PropertyGroup = model.PropertyGroups[0],
                    UserKey = "XDayOfWeek2",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new DropDownListExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "نیاز به آموزش دارد؟" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    Values = new DropDownListExtendedPropertyValueModel[]
                    {
                        // fill
                    },
                    PropertyGroup = model.PropertyGroups[0],
                    UserKey = "DoesNeedTutorial",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new DropDownListExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "منبع رزومه" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    Values = new DropDownListExtendedPropertyValueModel[]
                    {
                        new DropDownListExtendedPropertyValueModel{ Value = "بله" },
                        new DropDownListExtendedPropertyValueModel{ Value = "خیر" },
                    },
                    PropertyGroup = model.PropertyGroups[4],
                    UserKey = "Source", // mj
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new DropDownListExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "وضعیت رزومه" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    Values = new DropDownListExtendedPropertyValueModel[]
                    {
                        new DropDownListExtendedPropertyValueModel{ Value = "jobinja" },
                        new DropDownListExtendedPropertyValueModel{ Value = "linkedIn" },
                        new DropDownListExtendedPropertyValueModel{ Value = "coworkers" },
                        new DropDownListExtendedPropertyValueModel{ Value = "irantalent" },
                        new DropDownListExtendedPropertyValueModel{ Value = "jobvision" },
                        new DropDownListExtendedPropertyValueModel{ Value = "Quera" },
                        new DropDownListExtendedPropertyValueModel{ Value = "E-Estekhdam" },
                        new DropDownListExtendedPropertyValueModel{ Value = "ایمیل شرکت" },
                        new DropDownListExtendedPropertyValueModel{ Value = "Email Marketing" },
                        new DropDownListExtendedPropertyValueModel{ Value = "شبکه های اجتماعی" },
                    },
                    PropertyGroup = model.PropertyGroups[6],
                    UserKey = "ResumeStatus", // mj
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new DropDownListExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "نوع برگزاری مصاحبه دوم" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    Values = new DropDownListExtendedPropertyValueModel[]
                    {
                        new DropDownListExtendedPropertyValueModel{ Value = "تایید" },
                        new DropDownListExtendedPropertyValueModel{ Value = "رد" },
                        new DropDownListExtendedPropertyValueModel{ Value = "حضوری" },
                        new DropDownListExtendedPropertyValueModel{ Value = "غیرحضوری" },
                    },
                    PropertyGroup = model.PropertyGroups[0],
                    UserKey = "InterviewLocation",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new DropDownListExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "آیا نیاز به غربالگری دارد؟" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    Values = new DropDownListExtendedPropertyValueModel[]
                    {
                        new DropDownListExtendedPropertyValueModel{ Value = "بله" },
                        new DropDownListExtendedPropertyValueModel{ Value = "خیر" },
                    },
                    PropertyGroup = model.PropertyGroups[0],
                    UserKey = "DoesNeedFiltering",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new DropDownListExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "وضعیت تایید مصاحبه منابع انسانی" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    Values = new DropDownListExtendedPropertyValueModel[]
                    {
                        new DropDownListExtendedPropertyValueModel{ Value = "تایید حضور" },
                        new DropDownListExtendedPropertyValueModel{ Value = "مشغول شدن در شرکت دیگر" },
                        new DropDownListExtendedPropertyValueModel{ Value = "عدم پاسخگویی" },
                        new DropDownListExtendedPropertyValueModel{ Value = "درخواست تغییر زمان مصاحبه" },
                    },
                    PropertyGroup = model.PropertyGroups[0],
                    UserKey = "InterviewCDHR",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new DropDownListExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "آدرس مصاحبه منابع انسانی" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    Values = new DropDownListExtendedPropertyValueModel[]
                    {
                        new DropDownListExtendedPropertyValueModel{ Value = "شهرک غرب دادمان خ بهارستان پلاک ۷ جنب بانک مسکن ،طبقه اول، اتاق جلسات طبقه اول" },
                        new DropDownListExtendedPropertyValueModel{ Value = "غیرحضوری" },
                    },
                    PropertyGroup = model.PropertyGroups[0],
                    UserKey = "HumanResourceInterviewAddress",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new DropDownListExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "نیاز به جذب تخصصی دارد؟" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    Values = new DropDownListExtendedPropertyValueModel[]
                    {
                        new DropDownListExtendedPropertyValueModel{ Value = "✓" },
                        new DropDownListExtendedPropertyValueModel{ Value = "✗" },
                    },
                    PropertyGroup = model.PropertyGroups[0],
                    UserKey = "SpecialReqruiment",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new DropDownListExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "پلتفرم مصاحبه غیر حضوری اول" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    Values = new DropDownListExtendedPropertyValueModel[]
                    {
                        new DropDownListExtendedPropertyValueModel{ Value = "Google Meet" },
                    },
                    PropertyGroup = model.PropertyGroups[0],
                    UserKey = "MeetingPlatform1",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new DropDownListExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "دلیل رد در مصاحبه" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    Values = new DropDownListExtendedPropertyValueModel[]
                    {
                        new DropDownListExtendedPropertyValueModel{ Value = "کافی نبودن دانش فنی" },
                        new DropDownListExtendedPropertyValueModel{ Value = "فراتر بودن از حد انتظار" },
                        new DropDownListExtendedPropertyValueModel{ Value = "نامرتبط بودن تجربیات" },
                        new DropDownListExtendedPropertyValueModel{ Value = "عدم تطابق حقوق درخواستی با موقعیت شغلی" },
                        new DropDownListExtendedPropertyValueModel{ Value = "نداشتن سابقه کار مرتبط کافی" },
                        new DropDownListExtendedPropertyValueModel{ Value = "عدم تطابق محل سکونت و محل کار" },
                        new DropDownListExtendedPropertyValueModel{ Value = "عدم حضور مصاحبه شونده" },
                        new DropDownListExtendedPropertyValueModel{ Value = "پایین بودن نمره آزمون IQ" },
                        new DropDownListExtendedPropertyValueModel{ Value = "عدم تطابق فرد با فرهنگ و ساختار سازمان" },
                        new DropDownListExtendedPropertyValueModel{ Value = "مشغول شدن در شرکت دیگر " },
                        new DropDownListExtendedPropertyValueModel{ Value = "پر شدن موقعیت شغلی" },
                        new DropDownListExtendedPropertyValueModel{ Value = "عدم انگیزه کافی" },
                        new DropDownListExtendedPropertyValueModel{ Value = "عدم پذیرش شرایط قراردادی شرکت" },
                        new DropDownListExtendedPropertyValueModel{ Value = "تمایل به دورکاری یا کار پاره وقت" },
                        new DropDownListExtendedPropertyValueModel{ Value = "عدم تطابق با شایستگی های رفتاری شغل" },
                        new DropDownListExtendedPropertyValueModel{ Value = "کافی نبودن ظاهر و استایل کاری" },
                        new DropDownListExtendedPropertyValueModel{ Value = "عدم توافق برای زمان شروع به کار" },
                        new DropDownListExtendedPropertyValueModel{ Value = "سایر (استفاده نشود)" },
                    },
                    PropertyGroup = model.PropertyGroups[0],
                    UserKey = "InterviewRejectReason",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new DropDownListExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "وضعیت تایید مصاحبه دوم" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    Values = new DropDownListExtendedPropertyValueModel[]
                    {
                        new DropDownListExtendedPropertyValueModel{ Value = "تایید حضور" },
                        new DropDownListExtendedPropertyValueModel{ Value = "مشغول شدن در شرکت دیگر" },
                        new DropDownListExtendedPropertyValueModel{ Value = "عدم پاسخگویی" },
                        new DropDownListExtendedPropertyValueModel{ Value = "درخواست تغییر زمان مصاحبه" },
                    },
                    PropertyGroup = model.PropertyGroups[0],
                    UserKey = "InterviewCD2",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new DropDownListExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "نوع برگزاری مصاحبه اول" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    Values = new DropDownListExtendedPropertyValueModel[]
                    {
                        new DropDownListExtendedPropertyValueModel{ Value = "غیرحضوری" },
                        new DropDownListExtendedPropertyValueModel{ Value = "حضوری" },
                    },
                    PropertyGroup = model.PropertyGroups[0],
                    UserKey = "FirstInterviewLocation",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new DropDownListExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "Xروز مصاحبه اول" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    Values = new DropDownListExtendedPropertyValueModel[]
                    {
                        new DropDownListExtendedPropertyValueModel{ Value = "شنبه" },
                        new DropDownListExtendedPropertyValueModel{ Value = "یکشنبه" },
                        new DropDownListExtendedPropertyValueModel{ Value = "دوشنبه" },
                        new DropDownListExtendedPropertyValueModel{ Value = "سه شنبه" },
                        new DropDownListExtendedPropertyValueModel{ Value = "چهارشنبه" },
                        new DropDownListExtendedPropertyValueModel{ Value = "پنجشنبه" },
                    },
                    PropertyGroup = model.PropertyGroups[0],
                    UserKey = "XDayOfWeek",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new DropDownListExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "وضعیت تایید مصاحبه اول" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    Values = new DropDownListExtendedPropertyValueModel[]
                    {
                        new DropDownListExtendedPropertyValueModel{ Value = "تایید حضور" },
                        new DropDownListExtendedPropertyValueModel{ Value = "مشغول شدن در شرکت دیگر" },
                        new DropDownListExtendedPropertyValueModel{ Value = "عدم پاسخگویی" },
                        new DropDownListExtendedPropertyValueModel{ Value = "درخواست تغییر زمان مصاحبه" },
                    },
                    PropertyGroup = model.PropertyGroups[0],
                    UserKey = "InterviewCD1",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new DropDownListExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "پلتفرم مصاحبه غیرحضوری دوم" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    Values = new DropDownListExtendedPropertyValueModel[]
                    {
                        new DropDownListExtendedPropertyValueModel{ Value = "Google Meet" },
                    },
                    PropertyGroup = model.PropertyGroups[0],
                    UserKey = "MeetingPlatform2",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new DropDownListExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "Xروز شروع به کار" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    Values = new DropDownListExtendedPropertyValueModel[]
                    {
                        new DropDownListExtendedPropertyValueModel{ Value = "شنبه" },
                        new DropDownListExtendedPropertyValueModel{ Value = "یکشنبه" },
                        new DropDownListExtendedPropertyValueModel{ Value = "دوشنبه" },
                        new DropDownListExtendedPropertyValueModel{ Value = "سه شنبه" },
                        new DropDownListExtendedPropertyValueModel{ Value = "چهارشنبه" },
                        new DropDownListExtendedPropertyValueModel{ Value = "پنجشنبه" },
                    },
                    PropertyGroup = model.PropertyGroups[0],
                    UserKey = "XDayOfWeek3",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new PersianDateExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "تاریخ مصاحبه اول" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[2],
                    UserKey = "FirstInterviewDate",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new PersianDateExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "تاریخ مصاحبه دوم" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[2],
                    UserKey = "SecondInterviewDate",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new PersianDateExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "تاریخ مصاحبه منابع انسانی" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[2],
                    UserKey = "HRInterviewDate",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new PersianDateExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "تاریخ پایان دوره آموزشی" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[2],
                    UserKey = "AgreedTrainingEndDate",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new PersianDateExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "تاریخ شروع به کار" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[2],
                    UserKey = "WorkingStartDate",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new PersianDateExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "تاریخ ارسال روزمه" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[4],
                    UserKey = "ResumeSendDate", // mj
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new PersianDateExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "تاریخ توافقی شروع آموزش" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[2],
                    UserKey = "AgreedTrainingStartDate",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new SecurityItemExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "Xهماهنگ کننده مصاحبه" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[5],
                    UserKey = "Coordinator", // mj
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new AppointmentExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "جلسه مصاحبه اول" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[5],
                    UserKey = "FirstInterviewMeeting",
                    DefaultValue = string.Empty,
                },
                new AppointmentExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "جلسه منابع انسانی" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[5],
                    UserKey = "HumanResourceInterviewMeeting",
                    DefaultValue = string.Empty,
                },
                new AppointmentExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "جلسه مصاحبه دوم" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[5],
                    UserKey = "SecondInterviewMeeting",
                    DefaultValue = string.Empty,
                },
                new CheckboxExtendedPropertyModel 
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "مصاحبه با متقاضی بسیار مهم است." },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[4],
                    UserKey = "Important", // mj
                    IsRequired = false,
                    DefaultValue = Convert.ToString(true),
                },
                new CheckboxExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "غیرقابل استفاده" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[6],
                    UserKey = "Obsolete", // mj
                    IsRequired = false,
                    DefaultValue = Convert.ToString(false),
                },
                new UserExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "تنظیم کننده مصاحبه منابع انسانیX" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[5],
                    UserKey = "HRInterviewArranger",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new UserExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "مصاحبه کننده منابع انسانی" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[5],
                    UserKey = "HRInterviewer",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new UserExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "مصاحبه کننده اول" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[0],
                    UserKey = "FirstAssessor", // mj
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new UserExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "تنظیم کننده مصاحبه اول-X" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[5],
                    UserKey = "FirstInterviewArranger",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new UserExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "مصاحبه کننده دوم" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[1],
                    UserKey = "SecondAssessor", // mj
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new TextExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value =  "شناسه مرجع" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[4],
                    UserKey = "SourceRefId", // mj
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new TextExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value =  "علت کنسل شدن شروع به کارX" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[5],
                    UserKey = "StartingWorkCancellationReason",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new TextExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value =  "نتیجه تست هوش" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[5],
                    UserKey = "IQTestResult",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new TextExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value =  "توضیحات هماهنگی مصاحبه منابع انسانی" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[5],
                    UserKey = "HRInterviewArangementDescription",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new TextExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value =  "Xاتاق برگزاری مصاحبه منابع انسانی" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[5],
                    UserKey = "XThirdMeetRoom",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new TextExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value =  "دلیل پیگیری برای تماس مجدد / پیشنهاد جهت متقاعدسازی متقاضی" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[5],
                    UserKey = "Text5",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new TextExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value =  "شماره موبایل متقاضی کار" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[5],
                    UserKey = "InterviewIdentityPhoneNumber",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new TextExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value =  "یادداشت تایید کننده" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[4],
                    UserKey = "ApproverNote", // mj
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new TextExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value =  "پیام وب سرویس" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[5],
                    UserKey = "WebServiceMessage",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new TextExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value =  "دلیل رد در غربالگری1" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[6],
                    UserKey = "FirstRejectReason", // mj
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new TextExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value =  "توضیحات شروع به کار" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[5],
                    UserKey = "StartingWorkDescription",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new TextExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value =  "توضیحات هماهنگی مصاحبه دوم" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[5],
                    UserKey = "SecondInterviewArrangementDescription",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new TextExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value =  "لینک مصاحبه غیرحضوری دوم" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[5],
                    UserKey = "MeetingLink2",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new TextExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value =  "Xاتاق  برگزاری مصاحبه اول" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[5],
                    UserKey = "XFirstMeetRoom",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new TextExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value =  "توضیحات مصاحبه دوم" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[5],
                    UserKey = "SecondInterviewDescription",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new TextExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value =  "لینک مصاحبه غیرحضوری اول" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[5],
                    UserKey = "MeetingLink1",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new TextExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value =  "Xاتاق برگزاری مصاحبه دوم" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[5],
                    UserKey = "XSecondMeetRoom",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new TextExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value =  "ملاحظات مصاحبه تلفنی" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[5],
                    UserKey = "PhoneCallInterviewRemarks",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new TextExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value =  "توضیحات هماهنگی مصاحبه اول" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[5],
                    UserKey = "FristInterviewArrangementDescription",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new TextExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value =  "عنوان آگهی" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[4],
                    UserKey = "Title", // mj
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new TextExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value =  "علت کنسل شدن مصاحبه اولX" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[5],
                    UserKey = "FirstInterviewCancellationReason",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new TextExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value =  "توضیحات مصاحبه منابع انسانی" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[5],
                    UserKey = "HRInterviewDescription",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new TextExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value =  "xحقوق درخواستی (ریال)" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[5],
                    UserKey = "RequestedSalary",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new TextExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value =  "تایید کننده رزومه" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[4],
                    UserKey = "Approver", // mj
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new TextExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value =  "علت کنسل شدن مصاحبه دومX" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[5],
                    UserKey = "SecondInterviewCancellationReason",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new TextExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value =  "توضیحات مصاحبه اول" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[5],
                    UserKey = "FirstInterviewDescription",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new TextExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value =  "علت کنسل شدن مصاحبه منابع انسانیX" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[5],
                    UserKey = "HRInterviewCancellationReason",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new PositionExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value =  "سمت شغلی" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[5],
                    UserKey = "JobPosition",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new PositionExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value =  "سمت مسئول هماهنگ کننده" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[5],
                    UserKey = "HRBP",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new FormExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "فرم درخواست جذب" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[4],
                    UserKey = "EmploymentRequestForm", //mj
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new FileExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "فایل رزومه" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[4],
                    UserKey = "ResumeFile", // mj
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new CurrencyExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "حقوق توافق شده (ریال)" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[5],
                    UserKey = "Salary",
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new TimeExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "ساعت مصاحبه منابع انسانی" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[5],
                    UserKey = "HRInterviewTime",
                    IsRequired = false,
                    DefaultValue = "00:00:00",
                },
                new TimeExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "ساعت شروع به کار" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[5],
                    UserKey = "WorkingStartTime",
                    IsRequired = false,
                    DefaultValue = "00:00:00",
                },
                new TimeExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "ساعت مصاحبه دوم" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[5],
                    UserKey = "SecondInterviewTime",
                    IsRequired = false,
                    DefaultValue = "00:00:00",
                },
                new TimeExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "ساعت مصاحبه اول" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[5],
                    UserKey = "FirstInterviewTime",
                    IsRequired = false,
                    DefaultValue = "00:00:00",
                },

            };

            return model;
        }
    }
}
