using Septa.PayamGostarClient.Initializer.Core.Abstractions;
using Septa.PayamGostarClient.Initializer.Core.Abstractions.CrmModel;
using Septa.PayamGostarClient.Initializer.Core.Abstractions.Utilities.Factories;
using Septa.PayamGostarClient.Initializer.Core.APIs.Abstractions;
using Septa.PayamGostarClient.Initializer.Core.Utilities.Factory;
using Septa.PayamGostarClient.Initializer.Core.Utilities.Validator;
using System;
using System.Threading.Tasks;

namespace Septa.PayamGostarClient.Initializer.Core
{
    public class CrmObjectModelInitializer : ICrmObjectModelInitializer
    {
        private readonly IInitServiceFactory _initServiceFactory;

        public CrmObjectModelInitializer(IPayamGostarApiClient payamGostarApiClient, string languageCulture)
        {
            _initServiceFactory = new InitServiceFactory(new MatchingValidator(), payamGostarApiClient, languageCulture);
        }

        public CrmObjectModelInitializer(IPayamGostarApiClient payamGostarApiClient) : this(payamGostarApiClient, "fa-IR")
        {

        }

        //public CrmObjectModelInitializer(CrmObjectModelInitializerConfig config)
        //{
        //    if (config.ClientService == null)
        //    {
        //        throw new ClientServiceConfigNullException("CrmObjectModelInitializerConfig.ClientService must be set!");
        //    }

        //    _initServiceFactory = new InitServiceFactory(new MatchingValidator(), new PayamGostarApiClient(config.ClientService));
        //}


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
