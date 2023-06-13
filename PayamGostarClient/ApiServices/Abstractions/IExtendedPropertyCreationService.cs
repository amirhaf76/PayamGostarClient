using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos.BaseStructure.Simple;
using System.Threading.Tasks;

namespace PayamGostarClient.ApiServices.Abstractions
{
    public interface IExtendedPropertyCreationService
    {
        Task<object> CreateAsync();
    }

    public interface IExtendedPropertyService
    {
        Task<object> CreateAsync(BaseExtendedPropertyDto baseProperty);
    }
}