using PayamGostarClient.ApiClient;
using PayamGostarClient.ApiClient.Abstractions;
using PayamGostarClient.ApiClient.Enums;
using PayamGostarClient.Initializer.Abstractions;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;
using PayamGostarClient.Initializer.Exceptions;
using PayamGostarClient.Initializer.Extensions;
using PayamGostarClient.Initializer.Services;

namespace PayamGostarClient.Initializer.Factory
{
    public class InitServiceFactory : IInitServiceFactory
    {
        private readonly IPayamGostarApiClient _payamGostarApiClient;

        public InitServiceFactory(InitServiceFactoryConfig config)
        {
            _payamGostarApiClient = new PayamGostarApiClient(config.ClientService);

            BaseInitServiceExtension.LanguageCulture = config.ClientService.LanguageCulture;
        }

        public IInitService Create(BaseCRMModel model)
        {
            switch (model.Type)
            {
                case Gp_CrmObjectType.Form:
                    return new FormInitService(model as CrmFormModel, _payamGostarApiClient);
                case Gp_CrmObjectType.Ticket:
                    return new TicketInitService(model as CrmTicketModel, _payamGostarApiClient);
                case Gp_CrmObjectType.Identity:
                    return new IdentityService(model as CrmIdentityModel, _payamGostarApiClient);
                default:
                    throw new InvalidGpCrmObjectTypeException($"CrmModel with '{model.Code}' code has unsupported model type! ModelType: '{model.Type}'.");
            }
        }

    }


}
