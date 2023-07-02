using PayamGostarClient.ApiClient.Dtos.ExtendedPropertyApiClientDtos.BaseStructure.Simple;

namespace PayamGostarClient.ApiClient.Abstractions.Customization.ExtendedProperty.ExtendedPropertyCreation
{
    internal interface IExtendedPropertyCreationFactory
    {
        IExtendedPropertyCreation Create(BaseExtendedPropertyDto baseProperty);
    }
}