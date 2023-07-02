using PayamGostarClient.ApiClient.Dtos.PropertyGroupApiClientDtos;
using PayamGostarClient.Helper.Net;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiClient.Abstractions.Customization.PropertyGroup
{
    public interface IPayamGostarPropertyGroupApiClient
    {
        Task<ApiResponse<CrmObjectPropertyGroupCreationResultDto>> CreateAsync(CrmObjectPropertyGroupCreationRequestDto request);
    }
}