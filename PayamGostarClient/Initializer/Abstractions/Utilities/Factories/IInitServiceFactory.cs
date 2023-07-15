using PayamGostarClient.Initializer.Abstractions.CrmModel;
using PayamGostarClient.Initializer.Abstractions.InitServices;

namespace PayamGostarClient.Initializer.Abstractions.Utilities.Factories
{
    public interface IInitServiceFactory
    {

        IInitService Create(ICustomizationCrmModel model);
    }



}
