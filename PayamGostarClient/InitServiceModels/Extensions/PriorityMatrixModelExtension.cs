using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeTicketServiceDtos.Create;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeTicketServiceDtos.Get;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.CrmObjectTypeModels;
using System.Linq;

namespace PayamGostarClient.InitServiceModels.Extensions
{
    internal static class PriorityMatrixModelExtension
    {
        internal static PriorityMatrixCreateRequestDto ToDto(this PriorityMatrixModel model)
        {
            return new PriorityMatrixCreateRequestDto
            {
                Details = model.Details?.Select(p => p.ToDto()),
            };
        }

        internal static PriorityMatrixDetailCreateRequestDto ToDto(this PriorityMatrixDetailModel model)
        {
            return new PriorityMatrixDetailCreateRequestDto
            {
                ImpactIndex = model.ImpactIndex,
                PriorityIndex = model.PriorityIndex,
                SeverityIndex = model.SeverityIndex,
            };
        }

        internal static PriorityMatrixModel ToModel(this PriorityMatrixsGetResultDto dto)
        {
            return new PriorityMatrixModel
            {
                Details = dto.Details?.Select(x => x.ToModel()).ToArray(),
            };
        }

        internal static PriorityMatrixDetailModel ToModel(this PriorityMatrixGetResultDto dto)
        {
            return new PriorityMatrixDetailModel
            {
                ImpactIndex = dto.ImpactIndex,
                SeverityIndex = dto.SeverityIndex,
                PriorityIndex = dto.PriorityIndex,
            };
        }

    }
}
