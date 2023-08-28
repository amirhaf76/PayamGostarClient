using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Create;
using System;

namespace Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeTicketApiClientDtos.Create
{
    public class CrmObjectTypeTicketCreateRequestDto : BaseCrmObjectTypeCreateRequestDto
    {
        public Guid ListenLineId { get; set; }
        public string ResponseTemplate { get; set; }
        public PriorityMatrixCreateRequestDto PriorityMatrix { get; set; }

    }
}
