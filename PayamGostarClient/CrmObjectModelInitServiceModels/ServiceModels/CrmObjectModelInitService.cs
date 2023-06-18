using PayamGostarClient.CrmObjectModelInitServiceModels.Abstractions;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.CrmObjectTypeModels;
using PayamGostarClient.CrmObjectModelInitServiceModels.Exceptions;
using PayamGostarClient.InitServiceModels.Factory;
using System.Threading.Tasks;

namespace PayamGostarClient.CrmObjectModelInitServiceModels.ServiceModels
{
    public class CrmObjectModelInitService : ICrmObjectModelInitService
    {
        private readonly CrmObjectModelInitServiceConfig _config;

        public CrmObjectModelInitService(CrmObjectModelInitServiceConfig config)
        {
            _config = config;

            if (config.ClientService == null)
            {
                throw new ClientServiceConfigNullException();
            }
        }

        public async Task<bool> CheckSchemaAsync(params BaseCRMModel[] crmModels)
        {
            var initServiceFactoryConfig = new InitServiceFactoryConfig { ClientService = _config.ClientService };

            var initServiceFactory = new InitServiceFactory(initServiceFactoryConfig);

            foreach (var crmModel in crmModels)
            {
                var initService = initServiceFactory.Create(crmModel);

                return await initService.CheckSchemaAsync();
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
