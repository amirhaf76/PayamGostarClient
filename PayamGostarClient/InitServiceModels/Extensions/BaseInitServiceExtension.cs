using PayamGostarClient.ApiServices.Dtos;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeFormServiceDtos;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeServiceDtos;
using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.CrmObjectTypeModels;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.ExtendedPropertyModels;
using PayamGostarClient.InitServiceModels.Models;
using System.Linq;

namespace PayamGostarClient.InitServiceModels.Extensions
{
    internal static class BaseInitServiceExtension
    {

        internal static SearchedCrmObjectModel ToSearchedCrmObjectModel(this CrmObjectTypeSearchResultDto crmModel)
        {
            var crmObjectType = (Gp_CrmObjectType)crmModel.CrmOjectTypeIndex;

            return new SearchedCrmObjectModel(crmObjectType)
            {
                Id = crmModel.Id,
            }.CopyFromBaseCrmObjectTypeGetResultDto(crmModel);
        }


        internal static CrmFormModel ToCrmFormModel(this CrmObjectTypeFormGetResultDto crmModel)
        {
            var crmForm = new CrmFormModel
            {
                Prefix = crmModel.Prefix,
                Postfix = crmModel.Postfix,
                StartFrom = crmModel.StartFrom,
                DigitCount = crmModel.DigitCount,

            }.CopyFromBaseCrmObjectTypeGetResultDto(crmModel);

            if (crmModel.IsPublicForm)
            {
                crmForm.PublicForm = new CrmFormModel.PublicFormLogicModel
                {
                    FlushFormAfterSave = crmModel.FlushFormAfterSave,
                    IsAutoSubject = crmModel.IsAutoSubject,
                    SubmitMessage = crmModel.SubmitMessage,
                    RedirectAfterSuccessUrl = crmModel.RedirectAfterSuccessUrl,
                };
            }

            return crmForm;
        }


        internal static TTo CopyFromBaseCrmObjectTypeGetResultDto<TFrom, TTo>(this TTo to, TFrom from)
            where TTo: BaseCRMModel
            where TFrom: BaseCrmObjectTypeGetResultDto
        {
            to.Code = from.Code;
            to.Name = ToResourceValues(from.Name);
            to.Description = ToResourceValues(from.Description);
            to.Properties = from.Properties?.Select(p => p.ToBaseExtendedPropertyModel()).ToList();
            to.PropertyGroups = from.Groups?.Select(g => g.ToPropertyGroup()).ToList();
            to.Stages = from.Stages?.Select(p => p.ToStage()).ToList();
            

            return to;
        }


        // Todo: Warning! using hard code value for Language Culture.
        internal static ResourceValue[] ToResourceValues(string value)
        {
            return new ResourceValue[] { new ResourceValue { Value = value, LanguageCulture = "Fa" } };
        }

        internal static PropertyGroup ToPropertyGroup(this PropertyGroupGetResultDto group)
        {
            return new PropertyGroup
            {
                Name = ToResourceValues(group.Name),
                Expanded = group.ExpandForView,
                CountOfColumns = group.CountOfColumns ?? 0,
            };
        }

        internal static BaseExtendedPropertyModel ToBaseExtendedPropertyModel(this ExtendedPropertyGetResultDto property)
        {
            var type = (Gp_ExtendedPropertyType)property.PropertyDisplayTypeIndex;

            return new SearchedExtendedPropertyModel(type)
            {
                UserKey = property.UserKey,
                Name = ToResourceValues(property.Name),
                ToolTip = ToResourceValues(property.Tooltip),
                PropertyGroup = ToPropertyGroup(property.Group),
            };
        }

        internal static Stage ToStage(this StageGetResultDto stage)
        {
            return new Stage
            {
                Name = ToResourceValues(stage.Name),
                Enabled = stage.IsActive,
                IsDoneStage = stage.IsDoneStage,
                Key = stage.Key,
            };
        }

    }
}
