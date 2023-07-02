using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Create;
using System;

namespace PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeTicketApiClientDtos.Create
{
    public class CrmObjectTypeTicketCreateRequestDto : BaseCrmObjectTypeCreateRequestDto
    {
        public Guid ListenLineId { get; set; }
        public string ResponseTemplate { get; set; }
        public PriorityMatrixCreateRequestDto PriorityMatrix { get; set; }

    }
}
