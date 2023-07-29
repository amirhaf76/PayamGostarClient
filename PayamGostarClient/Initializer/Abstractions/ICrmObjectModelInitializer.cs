using PayamGostarClient.Initializer.Abstractions.CrmModel;
using System;
using System.Threading.Tasks;

namespace PayamGostarClient.Initializer.Abstractions
{
    public interface ICrmObjectModelInitializer
    {
        Task<bool> CheckExistenceSchemaAsync(params ICustomizationCrmModel[] crmModels);

        bool CheckExistenceSchema(params ICustomizationCrmModel[] crmModels);

        void Init(params ICustomizationCrmModel[] crmModels);

        void Init(Action<ICustomizationCrmModel> callBack, params ICustomizationCrmModel[] models);

        Task InitAsync(params ICustomizationCrmModel[] crmModels);

        Task InitAsync(Action<ICustomizationCrmModel> callBack, params ICustomizationCrmModel[] models);
    }
}
