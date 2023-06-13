using System.Threading.Tasks;

namespace PayamGostarClient.ApiServices.Abstractions
{
    public interface ICrmObjectTypeStageService
    {
        Task<object> CreateAsync(object obj);
    }
}