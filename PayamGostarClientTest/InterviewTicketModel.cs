using PayamGostarClient.Initializer.CrmModels;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;
using PayamGostarClient.Initializer.CrmModels.ExtendedPropertyModels;
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
                ResponseTemplate = string.Empty,
                ListenLineId = Guid.Parse("2b0e6171-e9ff-4aa2-b697-0fb95fa64237"),
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
                        Key = "Filtering"
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
                        Key = "FirstArrangement"
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
                        Key = "FirstInterview"
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
                        Key = "SecondArrangement"
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
                        Key = "SecondInterview"
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
                        Key = "HRInterviewArrangement"
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
                        Key = "HRInterview"
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
                        Key = "Hired",
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
                        Key = "Rejected"
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
                    UserKey = "CoordinatorX", // mj
                    IsRequired = false,
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
            };

            return model;
        }
    }
}
