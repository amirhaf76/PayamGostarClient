using PayamGostarClient.ApiServices.Dtos;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeFormServiceDtos;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeServiceDtos.Create;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeTicketServiceDtos.Create;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeTicketServiceDtos.Get;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.CrmObjectTypeModels;
using System.Linq;

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

    internal static class TicketInitServiceExtension
    {
        internal static CrmObjectTypeTicketCreateRequestDto ToDto(this CrmTicketModel model)
        {
            return new CrmObjectTypeTicketCreateRequestDto
            {
                ResponseTemplate = model.ResponseTemplate,
                PriorityMatrix = model.PriorityMatrix?.ToDto()

            }.FillBaseCrmObjectTypeCreateRequestDto(model);
        }

        internal static CrmTicketModel ToModel(this CrmObjectTypeTicketGetResultDto dto)
        {
            return new CrmTicketModel
            {
                ResponseTemplate = dto.ResponseTemplate,
                // matrix

            }.FillBaseCRMModel(dto);
        }
    }

    internal static class PriorityMatrixModelExtension
    {
        internal static PriorityMatrixCreateRequestDto ToDto(this PriorityMatrixModel model)
        {
            return new PriorityMatrixCreateRequestDto
            {
                Details = model.Details?.Select(p => p.ToDto()),
            };
        }

        internal static PriorityMatrixDetailCreateRequestDto ToDto(this PriorityMatrixDetailModel model)
        {
            return new PriorityMatrixDetailCreateRequestDto
            {
                ImpactIndex = model.ImpactIndex,
                PriorityIndex = model.PriorityIndex,
                SeverityIndex = model.SeverityIndex,
            };
        }

    }
}
