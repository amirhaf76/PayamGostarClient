﻿using PayamGostarClient.ApiServices.Abstractions;
using PayamGostarClient.ApiServices.Dtos.CrmObjectTypeServiceDtos;
using PayamGostarClient.ApiServices.Extension;
using System;
using System.Threading.Tasks;
using System.Linq;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;
using PayamGostarClient.Initializer.Extensions;

namespace PayamGostarClient.Initializer.Services
{
    public class FormInitService : BaseInitService<CrmFormModel>
    {
        public FormInitService(CrmFormModel crmFormModel, IPayamGostarClientServiceFactory crmObjectTypeApiService) : base(crmFormModel, crmObjectTypeApiService)
        {
        }

        protected override async Task<Guid> CreateTypeAsync()
        {
            var service = ServiceFactory.CreateCrmObjectTypeFormService();

            var creationResult = await service.CreateAsync(IntendedCrmObject.ToDto());

            return creationResult.Result.Id;
        }


    }

}