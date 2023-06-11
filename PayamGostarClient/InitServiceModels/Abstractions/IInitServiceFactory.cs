using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.CrmObjectTypeModels;

namespace PayamGostarClient.InitServiceModels.Abstractions
{
    public interface IInitServiceFactory
    {
        IInitService Create<T>(T model) where T : BaseCRMModel;
    }



}
