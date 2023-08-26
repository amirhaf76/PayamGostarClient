using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Enums;
using SeptaPay.PayamGostarClient.Initializer.Core.CrmModels;
using SeptaPay.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeModels;
using SeptaPay.PayamGostarClient.Initializer.Core.CrmModels.ExtendedPropertyModels;
using System;

namespace SeptaPay.PayamGostarClient.Initializer.Test.BuildInCrmObjectModels
{
    public class InterviewTicketModel
    {
        public const string FA_LANGUAGE_CULTURE = "fa-ir";

        public static CrmTicketModel Create(Guid line)
        {
            var model = new CrmTicketModel
            {
                Name = new ResourceValue[]
                {
                    new ResourceValue { LanguageCulture = FA_LANGUAGE_CULTURE,  Value = "مصاحبه",},
                },
                Description = new ResourceValue[]
                {
                    new ResourceValue { LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty },
                },
                Code = $"Interview",
                ResponseTemplate = string.Empty,
                ListenLineId = line,
                Enabled = true,
                PreviewTypeIndex = Gp_PreviewType.WordPreview,
                PropertyGroups = new System.Collections.Generic.List<PropertyGroup>
                {
                    new PropertyGroup()
                    {
                        Name = new[]
                        {
                            new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "اطلاعات متقاضی"},
                        },
                        CountOfColumns = 2,
                        Expanded = true,
                    },
                    new PropertyGroup()
                    {
                        Name = new[]
                        {
                            new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "هماهنگی مصاحبه اول"},
                        },
                        CountOfColumns = 2,
                        Expanded = true,
                    },
                    new PropertyGroup()
                    {
                        Name = new[]
                        {
                            new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "هماهنگی مصاحبه دوم"},
                        },
                        CountOfColumns = 2,
                        Expanded = true,
                    },
                    new PropertyGroup()
                    {
                        Name = new[]
                        {
                            new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "هماهنگی مصاحبه منابع انسانی"},
                        },
                        CountOfColumns = 2,
                        Expanded = true,
                    },
                    new PropertyGroup()
                    {
                        Name = new[]
                        {
                            new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "اطلاعات مصاحبه"},
                        },
                        CountOfColumns = 2,
                        Expanded = true,
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
                    PropertyGroup = model.PropertyGroups[0],
                    UserKey = "Title", // mj
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
                    PropertyGroup = model.PropertyGroups[0],
                    UserKey = "ResumeFile", // mj
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

                        new DropDownListExtendedPropertyValueModel{ Value = "Jobinja" },
                        new DropDownListExtendedPropertyValueModel{ Value = "LinkedIn" },
                        new DropDownListExtendedPropertyValueModel{ Value = "Coworkers" },
                        new DropDownListExtendedPropertyValueModel{ Value = "Irantalent" },
                        new DropDownListExtendedPropertyValueModel{ Value = "Jobvision" },
                        new DropDownListExtendedPropertyValueModel{ Value = "Quera" },
                        new DropDownListExtendedPropertyValueModel{ Value = "E-Estekhdam" },
                        new DropDownListExtendedPropertyValueModel{ Value = "Official Email" },
                        new DropDownListExtendedPropertyValueModel{ Value = "Email Marketing" },
                        new DropDownListExtendedPropertyValueModel{ Value = "Social Networks" },

                    },
                    PropertyGroup = model.PropertyGroups[0],
                    UserKey = "Source", // mj
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new PersianDateExtendedPropertyModel()
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = "تاریخ ارسال رزومه" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[0],
                    UserKey = "ResumeSendDate", // mj
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new TextExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value =  "غربال کننده رزومه" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[0],
                    UserKey = "Approver", // mj
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new TextExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value =  "توضیحات غربال کننده رزومه" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[0],
                    UserKey = "ApproverNote", // mj
                    IsRequired = false,
                    //IsMultiLine=true,
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
                        new DropDownListExtendedPropertyValueModel{ Value = "تایید" },
                        new DropDownListExtendedPropertyValueModel{ Value = "رد" },
                    },
                    PropertyGroup = model.PropertyGroups[0],
                    UserKey = "ResumeStatus", // mj
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new TextExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value =  "دلیل رد در پنل" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[0],
                    UserKey = "SourceRejectReason", // mj PlatformRejectReason
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
                    PropertyGroup = model.PropertyGroups[0],
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
                    PropertyGroup = model.PropertyGroups[0],
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
                    PropertyGroup = model.PropertyGroups[1],
                    UserKey = "FirstAssessor", // mj
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new TextExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value =  "توضیحات مصاحبه کننده اول" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[1],
                    UserKey = "FirstAssessorDescription", // mj
                    IsRequired = false,
                    //IsMultiLine=true,
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
                    PropertyGroup = model.PropertyGroups[2],
                    UserKey = "SecondAssessor", // mj
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new TextExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value =  "توضیحات مصاحبه کننده دوم" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[2],
                    UserKey = "SecondAssessorDescription", // mj
                    IsRequired = false,
                    //IsMultiLine=true,
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
                    PropertyGroup = model.PropertyGroups[3],
                    UserKey = "HRAssessor", // mj
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
                new TextExtendedPropertyModel
                {
                    Name = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value =  "توضیحات مصاحبه کننده منابع انسانی" },
                    },
                    ToolTip = new[]
                    {
                        new ResourceValue(){ LanguageCulture = FA_LANGUAGE_CULTURE, Value = string.Empty},
                    },
                    PropertyGroup = model.PropertyGroups[3],
                    UserKey = "HRAssessorDescription", // mj
                    IsRequired = false,
                    //IsMultiLine=true,
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
                    PropertyGroup = model.PropertyGroups[0],
                    UserKey = "SourceRefId", // mj
                    IsRequired = false,
                    DefaultValue = string.Empty,
                },
            };

            return model;
        }
    }
}
