using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.CrmObjectTypeModels;

namespace PayamGostarClient.InitServiceModels.Abstractions
{
    public interface IInitServiceFactory
    {
        IInitService Create(BaseCRMModel model);
    }



}
