using PayamGostarClient.ApiClient.Dtos.CrmObjectTypeServiceDtos.Get;
using PayamGostarClient.ApiClient.Dtos.CrmObjectTypeTicketServiceDtos.Create;
using System;

namespace PayamGostarClient.ApiClient.Dtos.CrmObjectTypeTicketServiceDtos.Get
{
    public class CrmObjectTypeTicketGetResultDto : BaseCrmObjectTypeGetResultDto
    {
        public int? NumberingTemplateId { get; set; }

        public Guid ListenLineId { get; set; }

        public string ResponseTemplate { get; set; }

        public PriorityMatrixsGetResultDto PriorityMatrix { get; set; }

    }
}
