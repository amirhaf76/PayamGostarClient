using SeptaPay.PayamGostarClient.Initializer.Core.APIs.Dtos.ExtendedPropertyApiClientDtos.BaseStructure.Simple;

namespace SeptaPay.PayamGostarClient.Initializer.Core.APIs.Abstractions.Customization.ExtendedProperty.ExtendedPropertyCreation
{
    public interface IExtendedPropertyCreationFactory
    {
        IExtendedPropertyCreation Create(BaseExtendedPropertyDto baseProperty);
    }
}