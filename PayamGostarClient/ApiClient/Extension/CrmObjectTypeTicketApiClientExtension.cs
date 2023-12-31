﻿using PayamGostarClient.ApiProvider;
using System;
using System.Collections.Generic;
using System.Text;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeTicketApiClientDtos.Get;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeTicketApiClientDtos.Create;

namespace PayamGostarClient.ApiClient.Extension
{
    internal static class CrmObjectTypeTicketApiClientExtension
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

        public static PriorityMatrixGetResultDto ToDto(this PriorityMatrixGetResultVM vm)
        {
            return new PriorityMatrixGetResultDto
            {
                Id = vm.Id,
                SeverityIndex = vm.SeverityIndex,
                ImpactIndex = vm.ImpactIndex,
                PriorityIndex = vm.PriorityIndex, 
            };
        }
    }
}
