using PayamGostarClient.CrmObjectModelInitServiceModels.Abstractions;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.CrmObjectTypeModels;
using PayamGostarClient.InitServiceModels.Factory;
using System.Threading.Tasks;

namespace PayamGostarClient.CrmObjectModelInitServiceModels.ServiceModels
{
    public class CrmObjectModelInitService : ICrmObjectModelInitService
    {
        private readonly CrmObjectModelInitServiceConfig _config;

        public CrmObjectModelInitService()
        {

        }

        public CrmObjectModelInitService(CrmObjectModelInitServiceConfig config)
        {
            _config = config;
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

                await initService.InitAsync<BaseCRMModel>();
            }
        }
    }


}
