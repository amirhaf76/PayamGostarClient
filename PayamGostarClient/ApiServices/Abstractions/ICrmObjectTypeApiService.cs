using PayamGostarClient.ApiProvider;
using PayamGostarClient.ApiServices.Dtos;
using PayamGostarClient.Helper.Net;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiServices.Abstractions
{
    public interface ICrmObjectTypeApiService
    {
        Task<ApiResponse<IEnumerable<CrmObjectTypeGetResultDto>>> SearchAsync(BaseCrmModelDto request);
    }
}