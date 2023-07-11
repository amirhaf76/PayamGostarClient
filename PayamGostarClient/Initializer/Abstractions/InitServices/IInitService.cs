using System.Threading.Tasks;

namespace PayamGostarClient.Initializer.Abstractions.InitServices
{
    public interface IInitService
    {
        Task InitAsync();

        Task<bool> CheckExistenceSchemaAsync();
    }

}
