using Septa.PayamGostarClient.Initializer.Core.Abstractions.Utilities.AbstractFactories;
using Septa.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeModels;
using Septa.PayamGostarClient.Initializer.Core.Utilities.Extensions;
using System;
using System.Threading.Tasks;

namespace Septa.PayamGostarClient.Initializer.Core.Services
{
    public class ReturnPurchaseInvoiceInitService : BaseInitService<CrmReturnPurchaseInvoiceModel>
    {
        internal ReturnPurchaseInvoiceInitService(CrmReturnPurchaseInvoiceModel intendedCrmObject, IInitServiceAbstractFactory factory) : base(intendedCrmObject, factory)
        {
        }

        protected override async Task<Guid> CreateTypeAsync()
        {
            var service = CrmObjectTypeApi.ReturnPurchaseInvoiceApi;

            var request = IntendedCrmObject.ToDto();

            var creationTicketResult = await service.CreateAsync(request);

            return creationTicketResult.Id;
        }
    }

}
