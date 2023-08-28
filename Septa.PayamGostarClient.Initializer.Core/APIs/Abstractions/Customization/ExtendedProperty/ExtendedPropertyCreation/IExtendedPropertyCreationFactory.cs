using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.ExtendedPropertyApiClientDtos.BaseStructure.Simple;

namespace Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.ExtendedProperty.ExtendedPropertyCreation
{
    public interface IExtendedPropertyCreationFactory
    {
        IExtendedPropertyCreation Create(BaseExtendedPropertyDto baseProperty);
    }
}