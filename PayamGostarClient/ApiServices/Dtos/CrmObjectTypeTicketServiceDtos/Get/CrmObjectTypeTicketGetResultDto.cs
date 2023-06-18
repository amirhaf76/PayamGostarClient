using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeServiceDtos;
using System;

namespace PayamGostarClient.ApiServices.Dtos.CrmObjectTypeTicketServiceDtos.Get
{
    public class CrmObjectTypeTicketGetResultDto : BaseCrmObjectTypeGetResultDto
    {
        public int? NumberingTemplateId { get; set; }

        public Guid ListenLineId { get; set; }

        public string ResponseTemplate { get; set; }

    }
}
