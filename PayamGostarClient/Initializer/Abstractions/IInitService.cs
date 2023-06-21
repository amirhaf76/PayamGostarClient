using System.Threading.Tasks;

namespace PayamGostarClient.Initializer.Abstractions
{
    public interface IInitService
    {
        Task InitAsync();

        Task<bool> CheckExistenceSchemaAsync();
    }

}
