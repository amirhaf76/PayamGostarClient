using System.Collections.Generic;

namespace SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeTicketApiClientDtos.Create
{
    public class PriorityMatrixCreateRequestDto
    {
        public PriorityMatrixCreateRequestDto()
        {
            Details = new List<PriorityMatrixDetailCreateRequestDto>();
        }

        public IEnumerable<PriorityMatrixDetailCreateRequestDto> Details { get; set; }
    }
}
