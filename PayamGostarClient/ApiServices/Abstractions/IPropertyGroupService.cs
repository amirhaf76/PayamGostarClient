using System.Threading.Tasks;

namespace PayamGostarClient.ApiServices.Abstractions
{
    public interface IPropertyGroupService
    {
        Task<object> CreateAsync(object obj);
    }
}