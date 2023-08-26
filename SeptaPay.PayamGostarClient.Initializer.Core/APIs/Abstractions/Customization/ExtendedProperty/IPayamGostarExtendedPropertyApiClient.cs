using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos;
using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.ExtendedPropertyApiClientDtos.BaseStructure.Simple;

using System.Threading.Tasks;

namespace SeptaPay.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.ExtendedProperty
{
    public interface IPayamGostarExtendedPropertyApiClient
    {
        Task<PropertyDefinitionCreationResultDto> CreateAsync(BaseExtendedPropertyDto baseProperty);
    }
}