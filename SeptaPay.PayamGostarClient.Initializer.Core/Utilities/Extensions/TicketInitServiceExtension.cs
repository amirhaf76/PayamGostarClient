using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeTicketApiClientDtos.Create;
using SeptaPay.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeModels;

namespace SeptaPay.PayamGostarClient.Initializer.Core.Utilities.Extensions
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
    }
}
