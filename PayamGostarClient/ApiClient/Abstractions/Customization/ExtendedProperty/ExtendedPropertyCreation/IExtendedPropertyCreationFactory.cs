using PayamGostarClient.ApiClient.Dtos.ExtendedPropertyServiceDtos.BaseStructure.Simple;

namespace PayamGostarClient.ApiClient.Abstractions.ExtendedPropertyCreation
{
    internal interface IExtendedPropertyCreationFactory
    {
        IExtendedPropertyCreation Create(BaseExtendedPropertyDto baseProperty);
    }
}