using PayamGostarClient.Initializer.Abstractions.CrmModel;
using System;
using System.Threading.Tasks;

namespace PayamGostarClient.Initializer.Abstractions
{
    public interface ICrmObjectModelInitializer
    {
        void Init(params ICustomizationCrmModel[] crmModels);

        Task InitAsync(params ICustomizationCrmModel[] crmModels);

        Task<bool> CheckExistenceSchemaAsync(params ICustomizationCrmModel[] crmModels);

        Task InitAsync(Action<ICustomizationCrmModel> callBack, params ICustomizationCrmModel[] models);
    }
}
