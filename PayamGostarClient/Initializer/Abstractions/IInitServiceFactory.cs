using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;

namespace PayamGostarClient.Initializer.Abstractions
{
    public interface IInitServiceFactory
    {
        // IInitService Create(BaseCRMModel model);

        IInitService Create(ICustomizationCrmModel model);
    }



}
