using PayamGostarClient.CrmObjectModelInitServiceModels.Abstractions;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.CrmObjectTypeModels;
using System;
using System.Threading.Tasks;

namespace PayamGostarClient.CrmObjectModelInitServiceModels.ServiceModels
{
    public class CrmObjectModelInitService : ICrmObjectModelInitService
    {
        private CrmObjectModelInitServiceConfig _config;

        public CrmObjectModelInitService()
        {

        }

        public CrmObjectModelInitService(CrmObjectModelInitServiceConfig config)
        {
            _config = config;
        }

        public void Init(params BaseCRMModel[] crmModels)
        {
            throw new NotImplementedException();
        }

        public async Task InitAsync(params BaseCRMModel[] crmModels)
        {
            var initServiceFactory = new InitServiceFactory();

            foreach (var crmModel in crmModels)
            {
                var initService = initServiceFactory.Create(crmModel);

                await initService.InitAsync<BaseCRMModel>();
            }
        }
    }


}
