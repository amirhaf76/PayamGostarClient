using PayamGostarClient.ApiClient.Abstractions;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;
using System;
using System.Threading.Tasks;

namespace PayamGostarClient.Initializer.Services
{
    public class PurchaseInvoiceInitService : BaseInitService<CrmPurchaseInvoiceModel>
    {
        public PurchaseInvoiceInitService(CrmPurchaseInvoiceModel intendedCrmObject, IPayamGostarApiClient payamGostarApiClient) : base(intendedCrmObject, payamGostarApiClient)
        {
            throw new NotImplementedException("PurchaseInvoiceInitService is not Implemented");
        }

        protected override Task<Guid> CreateTypeAsync()
        {
            throw new NotImplementedException();
        }
    }

}
