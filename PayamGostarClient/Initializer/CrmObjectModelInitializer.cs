﻿using PayamGostarClient.Initializer.Abstractions;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;
using PayamGostarClient.Initializer.Exceptions;
using PayamGostarClient.Initializer.Factory;
using System.Threading.Tasks;

namespace PayamGostarClient.Initializer
{
    public class CrmObjectModelInitializer : ICrmObjectModelInitializer
    {
        private readonly CrmObjectModelInitializerConfig _config;

        public CrmObjectModelInitializer(CrmObjectModelInitializerConfig config)
        {
            _config = config;

            if (config.ClientService == null)
            {
                throw new ClientServiceConfigNullException();
            }
        }

        public async Task<bool> CheckExistenceSchemaAsync(params BaseCRMModel[] crmModels)
        {
            var initServiceFactoryConfig = new InitServiceFactoryConfig { ClientService = _config.ClientService };

            var initServiceFactory = new InitServiceFactory(initServiceFactoryConfig);

            foreach (var crmModel in crmModels)
            {
                var initService = initServiceFactory.Create(crmModel);

                var isMatched = await initService.CheckExistenceSchemaAsync();

                if (!isMatched) return false;
            }

            return true;
        }

        public void Init(params BaseCRMModel[] crmModels)
        {
            SeptaKit.Extensions.SeptaKitTaskExtensions.RunSync(() => InitAsync(crmModels));
        }

        public async Task InitAsync(params BaseCRMModel[] crmModels)
        {
            var initServiceFactoryConfig = new InitServiceFactoryConfig { ClientService = _config.ClientService };

            var initServiceFactory = new InitServiceFactory(initServiceFactoryConfig);

            foreach (var crmModel in crmModels)
            {
                var initService = initServiceFactory.Create(crmModel);

                await initService.InitAsync();
            }
        }
    }


}