using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos;
using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.ExtendedPropertyApiClientDtos.BaseStructure.Simple;

using System.Threading.Tasks;

namespace Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.ExtendedProperty
{
    public interface IPayamGostarExtendedPropertyApiClient
    {
        Task<PropertyDefinitionCreationResultDto> CreateAsync(BaseExtendedPropertyDto baseProperty);

        PropertyDefinitionCreationResultDto Create(BaseExtendedPropertyDto baseProperty);
    }
}