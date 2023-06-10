using PayamGostarClient.ApiServices.Abstractions;
using PayamGostarClient.Models;
using System;

namespace PayamGostarClient
{
    public class InitServiceFactory : IInitServiceFactory
    {
        private ICrmObjectTypeApiService _crmObjectTypeApiService;

        public InitServiceFactory(InitServiceFactoryConfig config)
        {
            _crmObjectTypeApiService = CreateCrmObjectTypeApiService();

        }

        public InitServiceFactory() : this(InitServiceFactoryConfig.Default)
        {
        }

        private ICrmObjectTypeApiService CreateCrmObjectTypeApiService()
        {
            throw new NotImplementedException();
        }

        public IInitService Create<T>(T model) where T : BaseCRMModel
        {
            switch (model.Type)
            {
                case Gp_CrmObjectType.Form:
                    return new FormInitService(model, _crmObjectTypeApiService);
                default:
                    throw new InvalidGpCrmObjectTypeException();
            }
        }
    }


}
