using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeServiceDtos.Create;

namespace PayamGostarClient.ApiServices.Dtos.CrmObjectTypeTicketServiceDtos.Create
{
    public class CrmObjectTypeTicketCreateRequestDto : BaseCrmObjectTypeCreateRequestDto
    {
        public System.Guid ListenLineId { get; set; }
        public string ResponseTemplate { get; set; }
        public PriorityMatrixCreateRequestDto PriorityMatrix { get; set; }

    }
}
