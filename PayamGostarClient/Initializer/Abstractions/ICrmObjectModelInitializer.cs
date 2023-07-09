using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;
using System.Threading.Tasks;

namespace PayamGostarClient.Initializer.Abstractions
{
    public interface ICrmObjectModelInitializer
    {
        //void Init(params BaseCRMModel[] crmModels);

        // Task InitAsync(params BaseCRMModel[] crmModels);

        //Task<bool> CheckExistenceSchemaAsync(params BaseCRMModel[] crmModels);

        void Init(params ICustomizationCrmModel[] crmModels);

        Task InitAsync(params ICustomizationCrmModel[] crmModels);

        Task<bool> CheckExistenceSchemaAsync(params ICustomizationCrmModel[] crmModels);
    }
}
