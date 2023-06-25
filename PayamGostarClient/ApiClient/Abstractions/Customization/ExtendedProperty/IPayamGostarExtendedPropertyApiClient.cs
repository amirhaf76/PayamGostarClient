using PayamGostarClient.ApiClient.Dtos;
using PayamGostarClient.ApiClient.Dtos.ExtendedPropertyServiceDtos.BaseStructure.Simple;
using PayamGostarClient.Helper.Net;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiClient.Abstractions
{
    public interface IPayamGostarExtendedPropertyApiClient
    {
        Task<ApiResponse<PropertyDefinitionCreationResultDto>> CreateAsync(BaseExtendedPropertyDto baseProperty);
    }
}