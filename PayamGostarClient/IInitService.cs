using PayamGostarClient.Models;
using System.Threading.Tasks;

namespace PayamGostarClient
{
    public interface IInitService
    {
        Task InitAsync<T>() where T : BaseCRMModel;
    }

}
