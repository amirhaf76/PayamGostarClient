﻿using PayamGostarClient.ApiClient.Abstractions;
using PayamGostarClient.Initializer.Abstractions.Utilities.AbstractFactories;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;
using PayamGostarClient.Initializer.Utilities.Extensions;
using System;
using System.Threading.Tasks;

namespace PayamGostarClient.Initializer.Services
{
    public class InvoiceInitService : BaseInitService<CrmInvoiceModel>
    {
        public InvoiceInitService(CrmInvoiceModel intendedCrmObject, IPayamGostarApiClient payamGostarApiClient) : base(intendedCrmObject, payamGostarApiClient)
        {
        }

        internal InvoiceInitService(CrmInvoiceModel intendedCrmObject, IPayamGostarApiClient payamGostarApiClient, IInitServiceAbstractFactory factory) : base(intendedCrmObject, payamGostarApiClient, factory)
        {
        }

        protected override async Task<Guid> CreateTypeAsync()
        {
            var service = CrmObjectTypeApi.InvoiceApi;

            var request = IntendedCrmObject.ToDto();

            var creationTicketResult = await service.CreateAsync(request);

            return creationTicketResult.Result.Id;
        }
    }

}
