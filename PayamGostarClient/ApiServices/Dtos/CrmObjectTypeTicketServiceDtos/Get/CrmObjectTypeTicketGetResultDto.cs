﻿using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeServiceDtos;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeTicketServiceDtos.Create;
using System;

namespace PayamGostarClient.ApiServices.Dtos.CrmObjectTypeTicketServiceDtos.Get
{
    public class CrmObjectTypeTicketGetResultDto : BaseCrmObjectTypeGetResultDto
    {
        public int? NumberingTemplateId { get; set; }

        public Guid ListenLineId { get; set; }

        public string ResponseTemplate { get; set; }

        public PriorityMatrixsGetResultDto PriorityMatrix { get; set; }

    }
}
