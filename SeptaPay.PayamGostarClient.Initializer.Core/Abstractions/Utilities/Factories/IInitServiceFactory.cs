using SeptaPay.PayamGostarClient.Initializer.Core.Abstractions.CrmModel;
using SeptaPay.PayamGostarClient.Initializer.Core.Abstractions.InitServices;

namespace SeptaPay.PayamGostarClient.Initializer.Core.Abstractions.Utilities.Factories
{
    public interface IInitServiceFactory
    {

        IInitService Create(ICustomizationCrmModel model);
    }



}
