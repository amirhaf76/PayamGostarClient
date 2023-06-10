using PayamGostarClient.Models;

namespace PayamGostarClient
{
    public interface IInitServiceFactory
    {
        IInitService Create<T>(T model) where T : BaseCRMModel;
    }



}
