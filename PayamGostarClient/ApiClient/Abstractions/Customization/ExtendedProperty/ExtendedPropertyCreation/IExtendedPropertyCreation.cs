using PayamGostarClient.ApiClient.Dtos;
using PayamGostarClient.Helper.Net;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiClient.Abstractions.Customization.ExtendedProperty.ExtendedPropertyCreation
{
    internal interface IExtendedPropertyCreation
    {
        Task<ApiResponse<PropertyDefinitionCreationResultDto>> CreateAsync();
    }
}