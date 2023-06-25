using PayamGostarClient.ApiClient.Dtos.CrmObjectTypeFormServiceDtos.Create;
using PayamGostarClient.ApiClient.Dtos.CrmObjectTypeFormServiceDtos.Gets;
using PayamGostarClient.ApiClient.Dtos.CrmObjectTypeServiceDtos;
using PayamGostarClient.ApiClient.Dtos.CrmObjectTypeServiceDtos.Get;
using PayamGostarClient.Helper.Net;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiClient.Abstractions
{
    public interface IPayamGostarCrmObjectTypeFormApiClient
    {
        Task<ApiResponse<CrmObjectTypeFormGetResultDto>> GetAsync(CrmObjectTypeGetRequestDto request);

        Task<ApiResponse<CrmObjectTypeResultDto>> CreateAsync(CrmObjectTypeFormCreateRequestDto request);

    }
}