using PayamGostarClient.Initializer.Abstractions;
using PayamGostarClient.Initializer.Abstractions.CrmModel;
using PayamGostarClient.Initializer.Abstractions.Utilities.Factories;
using PayamGostarClient.Initializer.Exceptions;
using PayamGostarClient.Initializer.Utilities.Factory;
using System;
using System.Threading.Tasks;

namespace PayamGostarClient.Initializer
{
    public class CrmObjectModelInitializer : ICrmObjectModelInitializer
    {
        private readonly IInitServiceFactory _initServiceFactory;


        public CrmObjectModelInitializer(CrmObjectModelInitializerConfig config)
        {
            if (config.ClientService == null)
            {
                throw new ClientServiceConfigNullException("CrmObjectModelInitializerConfig.ClientService must be set!");
            }

            var initServiceFactoryConfig = new InitServiceFactoryConfig { ClientService = config.ClientService };

            _initServiceFactory = new InitServiceFactory(initServiceFactoryConfig);
        }


        public async Task<bool> CheckExistenceSchemaAsync(params ICustomizationCrmModel[] models)
        {
            foreach (var crmModel in models)
            {
                var initService = _initServiceFactory.Create(crmModel);

                var isMatched = await initService.CheckExistenceSchemaAsync();

                if (!isMatched) return false;
            }

            return true;
        }

        public bool CheckExistenceSchema(params ICustomizationCrmModel[] models)
        {
            return SeptaKit.Extensions.SeptaKitTaskExtensions.RunSync(() => CheckExistenceSchemaAsync(models));
        }

        public async Task InitAsync(Action<ICustomizationCrmModel> callBack, params ICustomizationCrmModel[] models)
        {
            foreach (var model in models)
            {
                var initService = _initServiceFactory.Create(model);

                await initService.InitAsync();

                callBack?.Invoke(model);
            }
        }

        public async Task InitAsync(params ICustomizationCrmModel[] models)
        {
            await InitAsync(null, models);
        }

        public void Init(params ICustomizationCrmModel[] models)
        {
            Init(null, models);
        }

        public void Init(Action<ICustomizationCrmModel> callBack, params ICustomizationCrmModel[] models)
        {
            SeptaKit.Extensions.SeptaKitTaskExtensions.RunSync(() => InitAsync(callBack, models));
        }
    }


}
