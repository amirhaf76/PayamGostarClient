﻿using PayamGostarClient.ApiServices.Abstractions;
using PayamGostarClient.ApiServices.Factory;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels;
using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.CrmObjectTypeModels;
using PayamGostarClient.InitServiceModels.Abstractions;
using PayamGostarClient.InitServiceModels.Exceptions;
using PayamGostarClient.InitServiceModels.Extensions;
using PayamGostarClient.InitServiceModels.Models;
using PayamGostarClient.InitServiceModels.Models.Services;
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

        //public IInitService Create<T>(T model) where T : BaseCRMModel
        //{
        //    switch (model.Type)
        //    {
        //        case Gp_CrmObjectType.Form:
        //            return new FormInitService(model as CrmFormModel, _serviceFactory);
        //        default:
        //            throw new InvalidGpCrmObjectTypeException();
        //    }
        //}

        private IPayamGostarClientServiceFactory CreatePayamGostarClientServiceFactory(InitServiceFactoryConfig config)
        {
            return new PayamGostarClientServiceFactory(config.ClientService);
        }
       
    }


}
