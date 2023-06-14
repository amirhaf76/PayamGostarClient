using PayamGostarClient.ApiServices.Dtos;
using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.BaseStructure.Simple;
using PayamGostarClient.Helper.Net;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiServices.Abstractions
{
    public interface IExtendedPropertyService
    {
        Task<ApiResponse<PropertyDefinitionCreationResultDto>> CreateAsync(BaseExtendedPropertyDto baseProperty);
    }
}