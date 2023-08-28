using System.Collections.Generic;

namespace Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeTicketApiClientDtos.Get
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
