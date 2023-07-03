using PayamGostarClient.ApiClient.Abstractions;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;
using System;
using System.Threading.Tasks;

namespace PayamGostarClient.Initializer.Services
{
    public class ReturnPurchaseInvoiceInitService : BaseInitService<CrmReturnPurchaseInvoiceModel>
    {
        public ReturnPurchaseInvoiceInitService(CrmReturnPurchaseInvoiceModel intendedCrmObject, IPayamGostarApiClient payamGostarApiClient) : base(intendedCrmObject, payamGostarApiClient)
        {
            throw new NotImplementedException("ReturnPurchaseInvoiceInitService is not Implemented");
        }

        protected override Task<Guid> CreateTypeAsync()
        {
            throw new NotImplementedException();
        }
    }

}
