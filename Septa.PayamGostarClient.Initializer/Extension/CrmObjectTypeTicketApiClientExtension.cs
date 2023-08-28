using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeTicketApiClientDtos.Create;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeTicketApiClientDtos.Get;
using Septa.PayamGostarClient.RestApi;

namespace Septa.PayamGostarClient.Initializer.Extension
{
    internal static class CrmObjectTypeTicketApiClientExtension
    {
        public static CrmObjectTypeTicketCreateRequestVM ToVM(this CrmObjectTypeTicketCreateRequestDto dto)
        {
            return new CrmObjectTypeTicketCreateRequestVM
            {
                ListenLineId = dto.ListenLineId,
                ResponseTemplate = dto.ResponseTemplate,
                PriorityMatrix = dto.PriorityMatrix?.ToVM(),

            }.FillBaseCrmObjectTypeCreateRequestVM(dto);
        }

        public static CrmObjectTypeTicketGetResultDto ToDto(this CrmObjectTypeTicketGetResultVM vm)
        {
            return new CrmObjectTypeTicketGetResultDto
            {
                NumberingTemplateId = vm.NumberingTemplateId,
                ListenLineId = vm.ListenLineId,
                ResponseTemplate = vm.ResponseTemplate,

            }.FillBaseCrmObjectTypeGetResultDto(vm);
        }

        public static PriorityMatrixGetResultDto ToDto(this PriorityMatrixGetResultVM vm)
        {
            return new PriorityMatrixGetResultDto
            {
                Id = vm.Id,
                SeverityIndex = vm.SeverityIndex,
                ImpactIndex = vm.ImpactIndex,
                PriorityIndex = vm.PriorityIndex,
            };
        }
    }
}
