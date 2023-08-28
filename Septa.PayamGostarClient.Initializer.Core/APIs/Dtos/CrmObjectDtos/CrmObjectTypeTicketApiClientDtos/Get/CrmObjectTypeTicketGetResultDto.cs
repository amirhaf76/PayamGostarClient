using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Get;
using System;

namespace Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeTicketApiClientDtos.Get
{
    public class CrmObjectTypeTicketGetResultDto : BaseCrmObjectTypeGetResultDto
    {
        public int? NumberingTemplateId { get; set; }

        public Guid ListenLineId { get; set; }

        public string ResponseTemplate { get; set; }

        public PriorityMatrixsGetResultDto PriorityMatrix { get; set; }

    }
}
