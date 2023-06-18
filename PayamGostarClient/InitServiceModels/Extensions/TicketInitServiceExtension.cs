using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeTicketServiceDtos.Create;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeTicketServiceDtos.Get;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.CrmObjectTypeModels;
using System.Linq;

namespace PayamGostarClient.InitServiceModels.Extensions
{
    internal static class TicketInitServiceExtension
    {
        internal static CrmObjectTypeTicketCreateRequestDto ToDto(this CrmTicketModel model)
        {
            return new CrmObjectTypeTicketCreateRequestDto
            {
                ResponseTemplate = model.ResponseTemplate,
                ListenLineId = model.ListenLineId,
                PriorityMatrix = model.PriorityMatrix?.ToDto()

            }.FillBaseCrmObjectTypeCreateRequestDto(model);
        }

        internal static CrmTicketModel ToModel(this CrmObjectTypeTicketGetResultDto dto)
        {
            return new CrmTicketModel
            {
                ResponseTemplate = dto.ResponseTemplate,
                ListenLineId = dto.ListenLineId,
                PriorityMatrix = dto.PriorityMatrix?.ToModel(),

            }.FillBaseCRMModel(dto);
        }
    }
}
