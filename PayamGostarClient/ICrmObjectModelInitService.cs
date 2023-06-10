using PayamGostarClient.Models;
using System.Threading.Tasks;

namespace PayamGostarClient
{
    public interface ICrmObjectModelInitService
    {
        void Init(params BaseCRMModel[] crmModels);

        Task InitAsync(params BaseCRMModel[] crmModels);
    }
}
