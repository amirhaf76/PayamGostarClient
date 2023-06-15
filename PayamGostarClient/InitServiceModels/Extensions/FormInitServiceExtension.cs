using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeFormServiceDtos;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeServiceDtos.Create;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.CrmObjectTypeModels;

namespace PayamGostarClient.InitServiceModels.Extensions
{
    internal static class FormInitServiceExtension
    {
        internal static CrmObjectTypeFormCreateRequestDto ToDto(this CrmFormModel model)
        {
            return new CrmObjectTypeFormCreateRequestDto
            {
                IsPublicForm = model.PublicForm != null,
                SubmitMessage = model.PublicForm?.SubmitMessage,
                FlushFormAfterSave = model.PublicForm?.FlushFormAfterSave ?? false,
                IsAutoSubject = model.PublicForm?.IsAutoSubject ?? false,
                RedirectAfterSuccessUrl = model.PublicForm?.RedirectAfterSuccessUrl,
                
                Prefix = model.Prefix,
                Postfix = model.Postfix,
                StartFrom = model.StartFrom,
                DigitCount = model.DigitCount,

            }.FillBaseCrmObjectTypeCreateRequestDto(model);

        }

        internal static CrmFormModel ToModel(this CrmObjectTypeFormGetResultDto crmModel)
        {
            var crmForm = new CrmFormModel
            {
                Prefix = crmModel.Prefix,
                Postfix = crmModel.Postfix,
                StartFrom = crmModel.StartFrom,
                DigitCount = crmModel.DigitCount,

            }.FillBaseCRMModel(crmModel);

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
    }
}
