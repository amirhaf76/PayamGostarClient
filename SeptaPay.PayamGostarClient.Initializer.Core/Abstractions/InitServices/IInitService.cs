using System.Threading.Tasks;

namespace SeptaPay.PayamGostarClient.Initializer.Core.Abstractions.InitServices
{
    public interface IInitService
    {
        Task InitAsync();

        Task<bool> CheckExistenceSchemaAsync();
    }

}
