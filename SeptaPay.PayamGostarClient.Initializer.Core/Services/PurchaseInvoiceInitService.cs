using SeptaPay.PayamGostarClient.Initializer.Core.Abstractions.Utilities.AbstractFactories;
using SeptaPay.PayamGostarClient.Initializer.Core.CrmModels.CrmObjectTypeModels;
using SeptaPay.PayamGostarClient.Initializer.Core.Utilities.Extensions;
using System;
using System.Threading.Tasks;

namespace SeptaPay.PayamGostarClient.Initializer.Core.Services
{
    public class PurchaseInvoiceInitService : BaseInitService<CrmPurchaseInvoiceModel>
    {
        internal PurchaseInvoiceInitService(CrmPurchaseInvoiceModel intendedCrmObject, IInitServiceAbstractFactory factory) : base(intendedCrmObject, factory)
        {
        }

        protected override async Task<Guid> CreateTypeAsync()
        {
            var service = CrmObjectTypeApi.PurchaseInvoiceApi;

            var request = IntendedCrmObject.ToDto();

            var creationTicketResult = await service.CreateAsync(request);

            return creationTicketResult.Id;
        }
    }

}
