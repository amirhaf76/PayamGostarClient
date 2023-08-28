using System.Threading.Tasks;

namespace Septa.PayamGostarClient.Initializer.Core.Abstractions.InitServices
{
    public interface IInitService
    {
        Task InitAsync();

        Task<bool> CheckExistenceSchemaAsync();
    }

}
