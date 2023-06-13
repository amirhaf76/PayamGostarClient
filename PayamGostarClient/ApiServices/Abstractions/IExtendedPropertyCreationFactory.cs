using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.BaseStructure.Simple;

namespace PayamGostarClient.ApiServices.Abstractions
{
    public interface IExtendedPropertyCreationFactory
    {
        IExtendedPropertyCreationService Create(BaseExtendedPropertyDto baseProperty);
    }
}