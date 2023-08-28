using Septa.PayamGostarClient.Initializer.Core.Abstractions.CrmModel;
using System;
using System.Threading.Tasks;

namespace Septa.PayamGostarClient.Initializer.Core.Abstractions
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
