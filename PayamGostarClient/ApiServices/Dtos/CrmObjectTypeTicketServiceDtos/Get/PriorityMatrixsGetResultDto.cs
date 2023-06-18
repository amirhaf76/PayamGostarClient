using System.Collections.Generic;

namespace PayamGostarClient.ApiServices.Dtos.CrmObjectTypeTicketServiceDtos.Get
{
    public class PriorityMatrixsGetResultDto
    {
        public PriorityMatrixsGetResultDto()
        {
            Details = new List<PriorityMatrixGetResultDto>();
        }

        public IEnumerable<PriorityMatrixGetResultDto> Details { get; set; }
    }
}
