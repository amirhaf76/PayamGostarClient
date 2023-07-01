using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Get;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeTicketApiClientDtos.Create;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeTicketApiClientDtos.Get;
using PayamGostarClient.Helper.Net;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiClient.Abstractions.Customization.CrmObjectType
{
    public interface IPayamGostarCrmObjectTypeTicketApiClient
    {
        Task<ApiResponse<CrmObjectTypeTicketGetResultDto>> GetWithPriorityMatrixAsync(CrmObjectTypeGetRequestDto request);

        Task<ApiResponse<CrmObjectTypeResultDto>> CreateAsync(CrmObjectTypeTicketCreateRequestDto request);
    }
}