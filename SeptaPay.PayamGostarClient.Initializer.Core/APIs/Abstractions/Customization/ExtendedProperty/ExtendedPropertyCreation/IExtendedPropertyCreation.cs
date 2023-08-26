using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos;
using System.Threading.Tasks;

namespace SeptaPay.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.ExtendedProperty.ExtendedPropertyCreation
{
    public interface IExtendedPropertyCreation
    {
        Task<PropertyDefinitionCreationResultDto> CreateAsync();
    }
}