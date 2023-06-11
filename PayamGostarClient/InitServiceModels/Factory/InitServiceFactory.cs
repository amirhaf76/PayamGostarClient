using PayamGostarClient.ApiServices.Abstractions;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.CrmObjectTypeModels;
using PayamGostarClient.InitServiceModels.Abstractions;
using PayamGostarClient.InitServiceModels.Exceptions;
using PayamGostarClient.InitServiceModels.Models;
using System;

namespace PayamGostarClient.InitServiceModels.Factory
{
    public class InitServiceFactory : IInitServiceFactory
    {
        private readonly IPayamGostarClientServiceFactory _serviceFactory;

        public InitServiceFactory() : this(InitServiceFactoryConfig.Default)
        {
        }

        public InitServiceFactory(InitServiceFactoryConfig config)
        {
            _serviceFactory = CreatePayamGostarClientServiceFactory(config);
        }

        public IInitService Create<T>(T model) where T : BaseCRMModel
        {
            switch (model.Type)
            {
                case Gp_CrmObjectType.Form:
                    return new FormInitService(model, _serviceFactory);
                default:
                    throw new InvalidGpCrmObjectTypeException();
            }
        }
        private IPayamGostarClientServiceFactory CreatePayamGostarClientServiceFactory(InitServiceFactoryConfig config)
        {
            throw new NotImplementedException();
        }
    }


}
