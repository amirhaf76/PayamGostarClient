using PayamGostarClient.ApiProvider;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeTicketServiceDtos.Create;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeTicketServiceDtos.Get;
using System;
using System.Collections.Generic;
using System.Text;


namespace PayamGostarClient.ApiServices.Extension
{
    internal static class CrmObjectTypeTicketServiceExtension
    {
        public static CrmObjectTypeTicketCreateRequestVM ToVM(this CrmObjectTypeTicketCreateRequestDto dto)
        {
            return new CrmObjectTypeTicketCreateRequestVM
            {
                ListenLineId = dto.ListenLineId,
                ResponseTemplate = dto.ResponseTemplate,
                PriorityMatrix = dto.PriorityMatrix?.ToVM(),

            }.FillBaseCrmObjectTypeCreateRequestVM(dto);
        }

        public static CrmObjectTypeTicketGetResultDto ToDto(this CrmObjectTypeTicketGetResultVM vm)
        {
            return new CrmObjectTypeTicketGetResultDto
            {
                NumberingTemplateId = vm.NumberingTemplateId,
                ListenLineId = vm.ListenLineId,
                ResponseTemplate = vm.ResponseTemplate,

            }.FillBaseCrmObjectTypeGetResultDto(vm);
        }
    }
}
