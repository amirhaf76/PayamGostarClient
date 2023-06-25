using PayamGostarClient.ApiClient.Dtos.CrmObjectTypeServiceDtos;
using PayamGostarClient.ApiClient.Dtos.CrmObjectTypeServiceDtos.Get;
using PayamGostarClient.ApiClient.Dtos.CrmObjectTypeTicketServiceDtos.Create;
using PayamGostarClient.ApiClient.Dtos.CrmObjectTypeTicketServiceDtos.Get;
using PayamGostarClient.Helper.Net;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiClient.Abstractions
{
    public interface IPayamGostarCrmObjectTypeTicketApiClient
    {
        Task<ApiResponse<CrmObjectTypeTicketGetResultDto>> GetWithPriorityMatrixAsync(CrmObjectTypeGetRequestDto request);

        Task<ApiResponse<CrmObjectTypeResultDto>> CreateAsync(CrmObjectTypeTicketCreateRequestDto request);
    }

    public interface IPayamGostarCrmObjectTypeIdentityApiClient
    {
        Task<ApiResponse<object>> CreateAsync(object request);
    }
}