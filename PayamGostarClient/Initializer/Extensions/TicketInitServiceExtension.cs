using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeTicketApiClientDtos.Create;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeTicketApiClientDtos.Get;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;
using System.Linq;

namespace PayamGostarClient.Initializer.Extensions
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
