using PayamGostarClient.ApiClient.Abstractions;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;
using System;
using System.Threading.Tasks;

namespace PayamGostarClient.Initializer.Services
{
    public class ReturnSaleInvoiceInitService : BaseInitService<CrmReturnSaleInvoiceModel>
    {
        public ReturnSaleInvoiceInitService(CrmReturnSaleInvoiceModel intendedCrmObject, IPayamGostarApiClient payamGostarApiClient) : base(intendedCrmObject, payamGostarApiClient)
        {
            throw new NotImplementedException("ReturnSaleInvoiceInitService is not Implemented");
        }

        protected override Task<Guid> CreateTypeAsync()
        {
            throw new NotImplementedException();
        }
    }

}
