using PayamGostarClient.ApiClient.Abstractions;
using PayamGostarClient.Initializer.CrmModels.CrmObjectTypeModels;
using System;
using System.Threading.Tasks;

namespace PayamGostarClient.Initializer.Services
{
    public class PaymentInitService : BaseInitService<CrmPaymentModel>
    {
        public PaymentInitService(CrmPaymentModel intendedCrmObject, IPayamGostarApiClient payamGostarApiClient) : base(intendedCrmObject, payamGostarApiClient)
        {
            throw new NotImplementedException("PaymentInitService is not Implemented");
        }

        protected override Task<Guid> CreateTypeAsync()
        {
            throw new NotImplementedException();
        }
    }

}
