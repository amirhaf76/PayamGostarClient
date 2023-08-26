using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeFormApiClientDtos.Create;
using SeptaPay.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeModels;

namespace SeptaPay.PayamGostarClient.Initializer.Core.Utilities.Extensions
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
    }
}
