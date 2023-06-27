using PayamGostarClient.ApiClient.Dtos.CrmObjectTypeServiceDtos.Create;
using System;

namespace PayamGostarClient.ApiClient.Dtos.CrmObjectTypeTicketServiceDtos.Create
{
    public class CrmObjectTypeTicketCreateRequestDto : BaseCrmObjectTypeCreateRequestDto
    {
        public Guid ListenLineId { get; set; }
        public string ResponseTemplate { get; set; }
        public PriorityMatrixCreateRequestDto PriorityMatrix { get; set; }

    }
}
