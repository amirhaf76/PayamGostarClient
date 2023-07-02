using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeApiClientDtos.Get;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeFormApiClientDtos.Create;
using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeFormApiClientDtos.Gets;
using PayamGostarClient.Helper.Net;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiClient.Abstractions.Customization.CrmObjectType
{
    public interface IPayamGostarCrmObjectTypeFormApiClient
    {
        Task<ApiResponse<CrmObjectTypeFormGetResultDto>> GetAsync(CrmObjectTypeGetRequestDto request);

        Task<ApiResponse<CrmObjectTypeResultDto>> CreateAsync(CrmObjectTypeFormCreateRequestDto request);

    }
}