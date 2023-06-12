using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeFormServiceDtos;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeServiceDtos;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeServiceDtos.Create;
using PayamGostarClient.Helper.Net;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiServices.Abstractions
{
    public interface ICrmObjectTypeFormService
    {
        Task<ApiResponse<CrmObjectTypeFormGetResultDto>> GetAsync(CrmObjectTypeGetRequestDto request);

        Task<ApiResponse<CrmObjectTypeResultDto>> CreateAsync(CrmObjectTypeFormCreateRequestDto request);

    }
}