using PayamGostarClient.ApiProvider;
using System.Linq;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeTicketApiClientDtos.Create;

namespace PayamGostarClient.ApiClient.Extension
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
