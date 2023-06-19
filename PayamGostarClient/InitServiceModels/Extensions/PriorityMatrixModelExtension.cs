using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeTicketServiceDtos.Create;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeTicketServiceDtos.Get;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.CrmObjectTypeModels;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.ExtendedPropertyModels;
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
                ImpactIndex = (int)model.ImpactIndex,
                PriorityIndex = (int)model.PriorityIndex,
                SeverityIndex = (int)model.SeverityIndex,
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
                ImpactIndex = (Gp_Matrix_Impact)dto.ImpactIndex,
                SeverityIndex = (Gp_Matrix_Severity)dto.SeverityIndex,
                PriorityIndex = (Gp_Matrix_Priority)dto.PriorityIndex,
            };
        }

    }
}
