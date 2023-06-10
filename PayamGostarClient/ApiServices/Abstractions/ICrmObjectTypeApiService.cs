using PayamGostarClient.ApiServices.Dtos;
using PayamGostarClient.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiServices.Abstractions
{
    public interface ICrmObjectTypeApiService
    {
        Task<IEnumerable<CrmObjectTypeGetResultDto>> SearchAsync(BaseCRMModel baseCRM);
    }
}