using PayamGostarClient.ApiServices.Dtos.PropertyGroupServiceDtos;
using PayamGostarClient.Helper.Net;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiServices.Abstractions
{
    public interface IPropertyGroupService
    {
        Task<ApiResponse<CrmObjectPropertyGroupCreationResultDto>> CreateAsync(CrmObjectPropertyGroupCreationRequestDto request);
    }
}