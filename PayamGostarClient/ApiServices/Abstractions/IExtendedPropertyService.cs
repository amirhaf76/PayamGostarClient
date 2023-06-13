using System.Threading.Tasks;

namespace PayamGostarClient.ApiServices.Abstractions
{
    public interface IExtendedPropertyService
    {
        Task<object> CreateAsync(object obj);
    }
}