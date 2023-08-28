using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Get;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeTicketApiClientDtos.Create;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos.CrmObjectTypeTicketApiClientDtos.Get;

using System.Threading.Tasks;

namespace Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.CrmObjectType
{
    public interface IPayamGostarCrmObjectTypeTicketApiClient
    {
        Task<CrmObjectTypeTicketGetResultDto> GetWithPriorityMatrixAsync(CrmObjectTypeGetRequestDto request);

        Task<CrmObjectTypeResultDto> CreateAsync(CrmObjectTypeTicketCreateRequestDto request);
    }
}