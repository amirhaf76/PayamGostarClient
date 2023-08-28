using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeTicketApiClientDtos.Create;
using Septa.PayamGostarClient.RestApi;
using System.Linq;

namespace Septa.PayamGostarClient.Initializer.Extension
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
