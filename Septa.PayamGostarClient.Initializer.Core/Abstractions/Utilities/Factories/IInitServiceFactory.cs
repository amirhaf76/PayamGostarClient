using Septa.PayamGostarClient.Initializer.Core.Abstractions.CrmModel;
using Septa.PayamGostarClient.Initializer.Core.Abstractions.InitServices;

namespace Septa.PayamGostarClient.Initializer.Core.Abstractions.Utilities.Factories
{
    public interface IInitServiceFactory
    {

        IInitService Create(ICustomizationCrmModel model);
    }



}
