using PayamGostarClient.ApiClient.Dtos;
using PayamGostarClient.ApiClient.Dtos.ExtendedPropertyApiClientDtos.BaseStructure.Simple;
using PayamGostarClient.Helper.Net;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiClient.Abstractions.Customization.ExtendedProperty
{
    public interface IPayamGostarExtendedPropertyApiClient
    {
        Task<ApiResponse<PropertyDefinitionCreationResultDto>> CreateAsync(BaseExtendedPropertyDto baseProperty);
    }
}