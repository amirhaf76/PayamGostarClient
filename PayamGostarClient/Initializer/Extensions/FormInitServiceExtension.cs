using PayamGostarClient.ApiClient.Dtos;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeFormApiClientDtos.Create;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeFormApiClientDtos.Gets;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;

namespace PayamGostarClient.Initializer.Extensions
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
