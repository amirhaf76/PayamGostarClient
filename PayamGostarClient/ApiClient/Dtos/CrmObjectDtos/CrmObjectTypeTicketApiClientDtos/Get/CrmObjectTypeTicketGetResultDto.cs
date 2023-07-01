using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Get;
using System;

namespace PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeTicketApiClientDtos.Get
{
    public class CrmObjectTypeTicketGetResultDto : BaseCrmObjectTypeGetResultDto
    {
        public int? NumberingTemplateId { get; set; }

        public Guid ListenLineId { get; set; }

        public string ResponseTemplate { get; set; }

        public PriorityMatrixsGetResultDto PriorityMatrix { get; set; }

    }
}
