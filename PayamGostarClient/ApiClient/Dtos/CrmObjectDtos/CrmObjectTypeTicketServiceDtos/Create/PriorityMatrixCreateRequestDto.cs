using System.Collections.Generic;

namespace PayamGostarClient.ApiClient.Dtos.CrmObjectTypeTicketServiceDtos.Create
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
