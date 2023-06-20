using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.CrmObjectTypeModels;
using System.Threading.Tasks;

namespace PayamGostarClient.CrmObjectModelInitServiceModels.Abstractions
{
    public interface ICrmObjectModelInitService
    {
        void Init(params BaseCRMModel[] crmModels);

        Task InitAsync(params BaseCRMModel[] crmModels);

        Task<bool> CheckExistenceSchemaAsync(params BaseCRMModel[] crmModels);
    }
}
