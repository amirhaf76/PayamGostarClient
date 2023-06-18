using PayamGostarClient.ApiProvider;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeTicketServiceDtos.Create;
using System.Linq;


namespace PayamGostarClient.ApiServices.Extension
{
    internal static class PriorityMatrixDtoExtension
    {
        public static PriorityMatrixCreateRequestVM ToVM(this PriorityMatrixCreateRequestDto dto)
        {
            return new PriorityMatrixCreateRequestVM
            {
                Details = dto.Details?.Select(p => p.ToVM()),
            };
        }

        public static PriorityMatrixDetailCreateRequestVM ToVM(this PriorityMatrixDetailCreateRequestDto dto)
        {
            return new PriorityMatrixDetailCreateRequestVM
            {
                PriorityIndex = dto.PriorityIndex,
                SeverityIndex = dto.SeverityIndex,
                ImpactIndex = dto.ImpactIndex,
            };
        }
    }
}
