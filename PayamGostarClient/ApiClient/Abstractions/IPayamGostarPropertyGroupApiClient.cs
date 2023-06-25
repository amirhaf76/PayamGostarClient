using PayamGostarClient.ApiClient.Dtos.PropertyGroupServiceDtos;
using PayamGostarClient.Helper.Net;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiClient.Abstractions
{
    public interface IPayamGostarPropertyGroupApiClient
    {
        Task<ApiResponse<CrmObjectPropertyGroupCreationResultDto>> CreateAsync(CrmObjectPropertyGroupCreationRequestDto request);
    }
}