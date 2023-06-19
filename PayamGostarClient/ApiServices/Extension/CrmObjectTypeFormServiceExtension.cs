using PayamGostarClient.ApiProvider;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeFormServiceDtos.Create;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeFormServiceDtos.Gets;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeServiceDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayamGostarClient.ApiServices.Extension
{
    public static class CrmObjectTypeFormServiceExtension
    {
        public static CrmObjectTypeFormGetResultDto ToDto(this CrmObjectTypeFormGetResultVM vmResult)
        {
            return new CrmObjectTypeFormGetResultDto
            {
                RedirectAfterSuccessUrl = vmResult.RedirectAfterSuccessUrl,
                SubmitMessage = vmResult.SubmitMessage,
                FlushFormAfterSave = vmResult.FlushFormAfterSave,
                IsAutoSubject = vmResult.IsAutoSubject,
                Prefix = vmResult.Prefix,
                Postfix = vmResult.Postfix,
                StartFrom = vmResult.StartFrom,
                DigitCount = vmResult.DigitCount,

            }.FillBaseCrmObjectTypeGetResultDto(vmResult);
        }

        public static CrmObjectTypeFormCreateRequestVM ToVM(this CrmObjectTypeFormCreateRequestDto request)
        {
            return new CrmObjectTypeFormCreateRequestVM
            {
                RedirectAfterSuccessUrl = request.RedirectAfterSuccessUrl,
                SubmitMessage = request.SubmitMessage,
                FlushFormAfterSave = request.FlushFormAfterSave,
                IsAutoSubject = request.IsAutoSubject,
                Prefix = request.Prefix,
                Postfix = request.Postfix,
                StartFrom = request.StartFrom,
                DigitCount = request.DigitCount,

            }.FillBaseCrmObjectTypeCreateRequestVM(request);
        }

    }
}
