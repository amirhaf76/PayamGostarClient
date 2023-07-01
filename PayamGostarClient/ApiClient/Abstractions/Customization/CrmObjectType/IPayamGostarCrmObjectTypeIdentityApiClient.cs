using PayamGostarClient.ApiClient.Dtos.CrmObjectDtos.CrmObjectTypeIdentityApiClientDtos.Get;
using PayamGostarClient.ApiClient.Dtos.CrmObjectTypeIdentityApiClientDtos.Create;
using PayamGostarClient.ApiClient.Dtos.CrmObjectTypeServiceDtos;
using PayamGostarClient.Helper.Net;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiClient.Abstractions
{
    public interface IPayamGostarCrmObjectTypeIdentityApiClient
    {
        Task<ApiResponse<CrmObjectTypeResultDto>> CreateAsync(CrmObjectTypeIdentityCreationRequestDto request);

        Task<ApiResponse<IEnumerable<ProfileTypeGetResultDto>>> GetProfileTypeAsync();
    }
}