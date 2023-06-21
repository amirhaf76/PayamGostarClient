using PayamGostarClient.ApiServices.Abstractions;
using PayamGostarClient.ApiServices.Factory;
using PayamGostarClient.Initializer.Abstractions;
using PayamGostarClient.Initializer.CrmModels;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;
using PayamGostarClient.Initializer.Exceptions;
using PayamGostarClient.Initializer.Extensions;
using PayamGostarClient.Initializer.Services;

namespace PayamGostarClient.Initializer.Factory
{
    public class InitServiceFactory : IInitServiceFactory
    {
        private readonly IPayamGostarClientServiceFactory _serviceFactory;

        public InitServiceFactory(InitServiceFactoryConfig config)
        {
            _serviceFactory = CreatePayamGostarClientServiceFactory(config);

            BaseInitServiceExtension.LanguageCulture = config.ClientService.LanguageCulture;
        }

        public IInitService Create(BaseCRMModel model)
        {
            switch (model.Type)
            {
                case Gp_CrmObjectType.Form:
                    return new FormInitService(model as CrmFormModel, _serviceFactory);
                case Gp_CrmObjectType.Ticket:
                    return new TicketInitService(model as CrmTicketModel, _serviceFactory);
                default:
                    throw new InvalidGpCrmObjectTypeException();
            }
        }

        private IPayamGostarClientServiceFactory CreatePayamGostarClientServiceFactory(InitServiceFactoryConfig config)
        {
            return new PayamGostarClientServiceFactory(config.ClientService);
        }

    }


}
