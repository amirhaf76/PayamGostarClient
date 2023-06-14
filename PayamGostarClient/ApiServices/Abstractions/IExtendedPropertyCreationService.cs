using PayamGostarClient.ApiServices.Dtos;
using PayamGostarClient.Helper.Net;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiServices.Abstractions
{
    public interface IExtendedPropertyCreationService
    {
        Task<ApiResponse<PropertyDefinitionCreationResultDto>> CreateAsync();
    }
}